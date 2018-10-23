using BE.API.Nutritionix.Result;
using BE.Models;
using DAL;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BL
{
   public class BlRouter : IBlRouter
    {
        private IDalRouter dalRouter { get; }
        public BlRouter()
        {
            dalRouter = new DalRouter();
        }

        public async Task AddMeal( Meal meal)
        {
           await dalRouter.AddMeal( meal);
        }

        public async Task<List<BodyDimmenssions>> GetBodyDimmenssions(DateTime start, DateTime end)
        {
            return await dalRouter.GetBodyDimmenssions(start, end);
        }

        public async Task<List<BodyDimmenssions>> GetBodyDimmenssions()
        {
            return await dalRouter.GetBodyDimmenssions();
        }

        public async Task<Guid> GetCurrentAccountId()
        {
            return  await dalRouter.GetCurrentAccountId();
        }

        public async Task<FoodNutritionsItem> GetFoodNutritions(string name)
        {
           return await dalRouter.GetFoodNutritions(name);
        }

        public async Task<List<FoodUnit>> GetSearchFood(string search)
        {
          return await dalRouter.GetSearchFood(search);
        }

        public async Task<BitmapImage> ImageFromUrl(string url)
        {
            return await dalRouter.ImageFromUrl(url);
        }

        public async Task MoveToGoogleLogin(IEventAggregator eventAggregator)
        {
          await  dalRouter.MoveToGoogleLogin(eventAggregator);
        }

        public Task<bool> GetislogOn()
        {
           return dalRouter.GetIslogOn();
        }

        public Task AddBodyDimmenssions(BodyDimmenssions bodyDimmenssions)
        {
            return dalRouter.AddBodyDimmenssions(bodyDimmenssions);
        }

        public async Task RegisterDataSave(BodyDimmenssions bodyDimmenssions, Profile profile)
        {
           await dalRouter.RegisterDataSave(bodyDimmenssions, profile);
        }

        public async Task<List<Activity>> GetActivityListAsync(DateTime dateTime)
        {
            return await dalRouter.GetActivityList(dateTime);
        }
    }
}
