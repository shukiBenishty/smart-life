using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API.Nutritionix
{
    class RapidAPIKeys
    {
        public String Project { get; set; }
        public String Key { get; set; }

        public RapidAPIKeys()
        {
            this.Project = "default-application_5b83ee5be4b070c2fc658cb6";
            this.Key = "4a9bf733-b594-42f7-834f-5740a0fbb9ca";
        }  
    }
}
