using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Models
{
    public class Meal
    {
        public Meal()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            this.FoodsInMeals = new List<FoodInMeal>();
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public List<FoodInMeal> FoodsInMeals { get; set; }
    }
}
