using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Models
{
  public  class SearchFood
    {
        public SearchFood()
        {
        }

        public SearchFood(string foodName)
        {
            FoodName = foodName;
            FoodUnitList = new List<FoodUnit>();
        }

        [Key]
        public String FoodName { get; set; }
        public List<FoodUnit> FoodUnitList { get; set; }
    }
}
