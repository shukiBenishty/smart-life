using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface IBLFoodLookupItems
    {
        Task<List<FoodLookupItem>> GetFoodLookupItemsAsycAsync(string search);
    }
}
