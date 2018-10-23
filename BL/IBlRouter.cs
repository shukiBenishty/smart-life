using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using BE.API.Nutritionix.Result;
using BE.Models;

namespace BL
{
    public interface IBlRouter
    {
        Task<FoodNutritionsItem> GetFoodNutritions(string name);
        Task<List<FoodUnit>> GetSearchFood(string search);
        Task<BitmapImage> ImageFromUrl(string url);

        Task<Guid> GetCurrentAccountId();
        Task AddMeal( Meal meal);
        Task<List<BodyDimmenssions>> GetBodyDimmenssions(DateTime start, DateTime end);
        Task AddBodyDimmenssions(BodyDimmenssions bodyDimmenssions);
        Task<List<BodyDimmenssions>> GetBodyDimmenssions();
        Task RegisterDataSave(BodyDimmenssions bodyDimmenssions, Profile profile);
        Task MoveToGoogleLogin(global::Prism.Events.IEventAggregator eventAggregator);
        Task<bool> GetislogOn();
        Task<List<Activity>> GetActivityListAsync(DateTime dateTime);
    }
}