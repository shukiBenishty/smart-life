using System.Collections.Generic;
using RapidAPISDK;
using System;
using System.Threading.Tasks;

namespace DAL.API.Nutritionix
{
    public class NutritionixBaseAPI
    {
       protected async Task< Dictionary<string, object>> Request(string search, NutritionixReqType nutritionixReqType)
        {
            var keysRapidApi = new RapidAPIKeys();
            RapidAPI RapidApi = new RapidAPI(keysRapidApi.Project, keysRapidApi.Key);

            var keysNutritionix = new NutritionixApiKeys();
            List<Parameter> body = new List<Parameter>
            {
                new DataParameter("applicationSecret", keysNutritionix.ApplicationSecret),
                new DataParameter("foodDescription", search),
                new DataParameter("applicationId", keysNutritionix.ApplicationId)
            };

            try
            {
                return await RapidApi.Call("Nutritionix", nutritionixReqType.ToString(), body.ToArray());
            }
            catch (RapidAPIServerException e)
            {
                //TODOO:  need the implemet 
            }
            catch (Exception e)
            {
                //TODOO:  need the implemet 

            }

            return null;
        }
    }
}
