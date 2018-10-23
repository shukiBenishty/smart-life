using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using SmartLife.DAL;

namespace BL
{
    public class FoodLookupItems : IBLFoodLookupItems
    {
        private IDAl _dal;

        public FoodLookupItems()
        {
            _dal = new Router();
        }

        public async Task<List<FoodLookupItem>> GetFoodLookupItemsAsycAsync(string search)
        {
            return await _dal.GetFoodLookupItemsAsyc(search);
        }
    }
}
