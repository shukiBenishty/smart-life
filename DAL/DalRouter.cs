using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using BE.API.Nutritionix.Result;
using BE.Models;
using DAL.API.Nutritionix;
using DAL.Tools;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Prism.Events;
using DAL.API.Google;

namespace DAL
{
    public class DalRouter : IDalRouter
    {
        private Login GetLogin { get; }
        public DalRouter()
        {
            DbContext = new DB.SmartLifeDbContext();
            GetLogin = new Login();
        }


        public DB.SmartLifeDbContext DbContext { get; set; }

        public async Task<FoodNutritionsItem> GetFoodNutritions(string name)
        {
            var result = await (from food in DbContext.FoodsNutritions
                                where food.FoodName == name
                                select food).SingleOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            return await new Nutritionix().GetFoodNutrition(name);
        }

        public async Task<Guid> GetFoodNutritionsId(string foodName)
        {
            try
            {
                var id = await GetFoodNutritionsIdFromDB(foodName);
                if (id != new Guid())
                {
                    return id;
                }
                var food = await new Nutritionix().GetFoodNutrition(foodName);
                return food.ID;
            }
            catch (Exception)
            {

                var food = await new Nutritionix().GetFoodNutrition(foodName);
                return food.ID;
            }


        }

        private async Task<Guid> GetFoodNutritionsIdFromDB(string foodName)
        {
            return await (from food in DbContext.FoodsNutritions
                          where food.FoodName == foodName
                          select food.ID).SingleOrDefaultAsync();
        }

        public async Task<List<FoodUnit>> GetSearchFood(string search)
        {
            try
            {
                return await (from searchItem in DbContext.SearchFood
                              where searchItem.FoodName == search
                              select searchItem.FoodUnitList).SingleAsync();


            }
            catch (Exception)
            {

                return await new Nutritionix().SearchFood(search);
            }




        }

        public async Task<BitmapImage> ImageFromUrl(string url)
        {
            return await new Download().ImageFromUrl(url);
        }

        public async Task<Guid> GetCurrentAccountId()
        {
            return await new Login().GetAccountId();
        }

        public async Task<List<BodyDimmenssions>> GetBodyDimmenssions(DateTime start, DateTime end)
        {
            var AccountId = await GetLogin.GetAccountId();
            var list = await DbContext.Accounts.Where(A => A.Id == AccountId).Select(A => A.BodyDimmenssionsList).SingleOrDefaultAsync();
            return list.Where(B => B.DateTime >= start && B.DateTime <= end).ToList();
        }

        public async Task<List<BodyDimmenssions>> GetBodyDimmenssions()
        {
            var AccountId = await GetLogin.GetAccountId();
            return await DbContext.Accounts.Where(A => A.Id == AccountId).Select(A => A.BodyDimmenssionsList).SingleOrDefaultAsync();
        }

        public async Task AddMeal(Meal meal)
        {
            var id = await GetLogin.GetAccountId();
            //var account = await GetAccountAsync(id);
            var account = await DbContext.Accounts
                .Where(A => A.Id == id)
                .Include(A => A.Meals).SingleOrDefaultAsync();
            if (account != null)
            {
                account.Meals.Add(meal);
                DbContext.SaveChanges();
            }

        }

        public async Task MoveToGoogleLogin(IEventAggregator eventAggregator)
        {
            var result = await OAuth.doOAuth();
            await new Login().TryGoogleLoginAsync(result, eventAggregator);
        }

        public Task<bool> GetIslogOn()
        {
            return new Login().GetIsLogOn();
        }

        public async Task AddBodyDimmenssions(BodyDimmenssions bodyDimmenssions)
        {
            var id = await GetLogin.GetAccountId();
            var account = await GetAccountAsync(id);
            account.BodyDimmenssionsList.Add(bodyDimmenssions);
            DbContext.SaveChanges();
        }



        private async Task<Account> GetAccountAsync(Guid id)
        {
            return await DbContext.Accounts.Where(a => a.Id == id).Include(a => a.Meals).SingleOrDefaultAsync();
        }

        public async Task RegisterDataSave(BodyDimmenssions bodyDimmenssions, Profile profile)
        {
            var id = await GetLogin.GetAccountId();
            var account = await GetAccountAsync(id);
            account.Profile = profile;
            account.BodyDimmenssionsList.Add(bodyDimmenssions);
            DbContext.SaveChanges();
        }

        public async Task<List<Activity>> GetActivityList(DateTime dateTime)
        {
            BE.API.Nutritionix.Result.FoodNutritionsItem nut;
            var id = await GetLogin.GetAccountId();
            try
            {
                var account = await DbContext.Accounts.Include(a => a.Meals).Include(a => a.Meals.Select(m => m.FoodsInMeals)).SingleOrDefaultAsync();


                var meals = account.Meals.Where(m => m.Date.Year == dateTime.Year && m.Date.Month == dateTime.Month
                      && m.Date.Day == dateTime.Day).ToList();
                List<Activity> result = new List<Activity>();
                foreach (var meal in meals)
                {
                    foreach (var food in meal.FoodsInMeals)
                    {
                        var activity = new Activity();
                        nut = await GetFoodNutritions(food.FoodName);
                        activity.Description += nut.FoodName;
                        activity.Amount = food.Quantity;
                        activity.Calories = nut.NfCalories * food.Quantity;
                        activity.Protein = nut.NfProtein * food.Quantity;
                        activity.Unit = nut.ServingUnit;
                        activity.NetCarbs = nut.NfTotalCarbohydrate * food.Quantity;
                        result.Add(activity);

                    }
                }
                return result;

            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
