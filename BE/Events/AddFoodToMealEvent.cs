using BE.API.Nutritionix.Result;
using BE.Models;
using Prism.Events;

namespace BE.Events
{
    public  class AddFoodToMealEvent :PubSubEvent<AddFoodToMealEventArg>
    {
    }

    public class AddFoodToMealEventArg
    {
        public FoodInMeal Food { get; set; }
        public FoodNutritionsItem Nutritions { set; get; }

    }
}
