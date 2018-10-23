using BE.API.Nutritionix.Result;
using LiveCharts;
using System.Windows.Controls;
using LiveCharts.Wpf;
using System;
using GUI.View;
using BE.Models;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using System.Diagnostics;
using GUI.Wrapper;

namespace GUI.ViewModel.MainScreen
{
    public class AddFoodItemViewModel : ViewModelBase
    {
        private SeriesCollection _seriesCollectionyVar;
        private Func<double, string> _formatter;
        private string[] _labels;
        private BL.IBlRouter blRouter;
        private Goals goals;

        
        private string _name;
        

        public  AddFoodItemViewModel(String name, IEventAggregator eventAggregator)
        {
            Quantity = 1;
            _eventAggregator = eventAggregator;
            AddFoodCommand = new DelegateCommand<Type>(OnAddFood, CanAddFood);
            _name = name;
             Init(_name);
        }

        private bool CanAddFood(Type arg)
        {
            return true;
        }

        private async void OnAddFood(Type obj)
        {
            if (Food ==null)
            {
                Food = await blRouter.GetFoodNutritions(_name);
            }
            _eventAggregator.GetEvent<BE.Events.AddFoodToMealEvent>()
                .Publish(new BE.Events.AddFoodToMealEventArg()
                {
                    Nutritions = Food,
                    Food = new FoodInMeal()
                    {
                        FoodName = _name,
                        Quantity = this.Quantity
                    }
                });
        }

        private async void Init(string name)
        {
            TestGolesInit();
            blRouter = new BL.BlRouter();
            Food = await blRouter.GetFoodNutritions(name);
        }

        private void TestGolesInit()
        {
            goals = new Goals()
            {
                CaloriesConsume = 1000,
                ProteinConsume = 300,
                TotalfatConsume = 100,
                CholesterolConsume = 30

            };
        }

      
        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollectionyVar;  }
            set { _seriesCollectionyVar = value; OnPropertyChanged(); }
        }

        public string[] Labels
        {
            get { return _labels; }
            set { _labels = value; OnPropertyChanged(); }
        }

        public Func<double, string> Formatter
        {
            get { return _formatter; }
            set { _formatter = value; OnPropertyChanged(); }
        }

        //private void InitCart()
        //{
        //    SeriesCollection = new SeriesCollection
        //    {
        //        new RowSeries
        //        {
        //            Title = _name,
        //            Values = new ChartValues<double> { ConverToInt(food.NfCalories), ConverToInt(food.NfProtein)
        //            , ConverToInt(food.NfTotalFat), ConverToInt(food.NfCholesterol) }
        //        }
        //    };

          
        //    SeriesCollection.Add(new RowSeries
        //    {
        //        Title = "Daily goal",
        //        Values = new ChartValues<double> { goals.CaloriesConsume, goals.ProteinConsume, goals.TotalfatConsume, goals.CholesterolConsume }
        //    });


        //    Labels = new[] { "Calories", "Frotein", "Fat", "Cholesterol" };
        //    Formatter = value => value.ToString("N");
        //}

        private double ConverToInt(double? value)
        {
            double result;
 
            if (double.TryParse(value.ToString(), out result))
            {
                return result;
            }
            return 0;
        }

    

        private IEventAggregator _eventAggregator;

        public ICommand AddFoodCommand { get; }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged(); }
        }


        private FoodNutritionsItem food;

        public FoodNutritionsItem Food
        {
            get { return food; }
            set { food = value; OnPropertyChanged(); }
        }

        
    }
}
