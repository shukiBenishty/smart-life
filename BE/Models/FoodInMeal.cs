using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Models
{
    public class FoodInMeal
    {
        public FoodInMeal()
        {
            ID = Guid.NewGuid();
        }

        public FoodInMeal(String foodName, int quantity)
        {
            ID = Guid.NewGuid();
            FoodName = foodName;
            Quantity = quantity;
        }

        [Key]
        public Guid ID { get; set; }

       
        public string FoodName { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
