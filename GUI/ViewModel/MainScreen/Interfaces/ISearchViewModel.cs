using System.Collections.ObjectModel;
using System.Windows.Input;
using BE.API.Nutritionix.Result;
using BE.Models;

namespace GUI.ViewModel
{
    public interface ISearchViewModel
    {
     
        string Search { get; set; }
      
       

        void SearchFoodsUnit();
    }
}