using BE.Models;
using DAL;
using Prism.Events;
using System;

namespace ConsoleTest
{
    class Program
    {
        static  void Main(string[] args)
        {
            var router = new DalRouter();
            var foodInMeal = new FoodInMeal("apple", 2);


            var meal = new Meal();
            meal.FoodsInMeals.Add(foodInMeal);

            router.AddMeal(meal).Wait();

        }

        

        private static void AddBodyDimmenssions(object account)
        {
            throw new NotImplementedException();
        }

        private async static void NewMethod(Login login)
        {
            var test13 = await login.GetIsLogOn();
        }

       

       
    }
}
