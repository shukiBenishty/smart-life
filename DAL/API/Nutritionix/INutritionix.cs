using BE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.API.Nutritionix
{
    public interface INutritionix
    {
        Task<List<FoodUnit>> SearchFood(string search, NutritionixReqType nutritionixReqType);
    }
}