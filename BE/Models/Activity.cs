using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Models
{
   public class Activity
    {
        public String Description { get; set; }
        public int Amount { get; set; }
        public String Unit { get; set; }
        public double? Calories { get; set; }
        public double? Protein { get; set; }
        public double? NetCarbs { get; set; }
        public double? Fat { get; set; }
    }
}
