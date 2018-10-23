using System;

namespace DAL.API.Nutritionix
{
    class NutritionixApiKeys
    {
        public NutritionixApiKeys()
        {
            this.ApplicationId = "fd435a66";
            this.ApplicationSecret = "8e7c6441e124aacc7e7dedff7fd95fa0";
        }
        public String ApplicationSecret { get; set; }
        public String ApplicationId { get; set; }
    }


}
