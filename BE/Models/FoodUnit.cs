using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BE.Models
{
    public class FoodUnit
    {
        public FoodUnit()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Key]
        public String Name { get; set; }

        public string ImageUrl { get; set; }

        public Guid FoodNutritionsItemID { get; set; }



    }
}
