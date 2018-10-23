using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using BE.Models;
using BE.API.Nutritionix.Result;
using System.Threading;
using DAL.DB;
using DAL.Tools;
using System.Data.Entity.Migrations;

namespace DAL.API.Nutritionix
{

    public class Nutritionix : NutritionixBaseAPI
    {
        public async Task<List<FoodUnit>> SearchFood(string search)
        {
           
            var db = new DAL.DB.SmartLifeDbContext();
            var result = new List<FoodUnit>();
            var response = await Request(search, NutritionixReqType.searchFoods);
            if (response.TryGetValue("success", out object payload))
            {
                var foodAutoComplete = SearchFoodsResult.FromJson(JsonConvert.SerializeObject(response));
                foreach (var item in foodAutoComplete.Success.Select(Success => Success.Common).First())
                {
                    var food = new FoodUnit()
                    {
                        Id = Guid.NewGuid(),
                        Name = item.FoodName,
                        ImageUrl = item.Photo.Thumb
                    };
                    result.Add(food);

                    db.FoodsUnits.AddOrUpdate(F => F.Name, food);
                }

                SaveData(search, db, result);
            }
            return result;
        }

        private static void SaveData(string search, SmartLifeDbContext db, List<FoodUnit> result)
        {
            var saveData = new SearchFood(search);
            saveData.FoodUnitList = result;
            db.SearchFood.AddOrUpdate(S => S.FoodName, saveData);
            db.SaveChangesAsync();
        }

        public async Task<FoodNutritionsItem> GetFoodNutrition(string foodName)
        {
            var response = await Request(foodName, NutritionixReqType.getFoodsNutrients);
            if (response.TryGetValue("success", out object payload))
            {
                var foodNutrition = GetFoodsNutrientsResultApi.FromJson(JsonConvert.SerializeObject(response));
                var food = ((foodNutrition.Success.First()).Foods.First());

                (new Thread(() =>
                {
                    var db = new SmartLifeDbContext();
                    try
                    {
                        db.FoodsNutritions.AddOrUpdate(food);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        //Do nothing
                        if (System.Diagnostics.Debugger.IsAttached == false)
                            System.Diagnostics.Debugger.Launch();
                    }

                })).Start();
                return food;
            }
            return null;
        }
    }
}
