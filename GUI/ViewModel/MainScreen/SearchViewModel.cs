using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BE.API.Nutritionix.Result;
using BE.Events;
using BE.Models;
using BL;
using GUI.View.Services;
using GUI.ViewModel.MainScreen;
using Prism.Commands;
using Prism.Events;

namespace GUI.ViewModel
{
    public class SearchViewModel : ViewModelBase, ISearchViewModel
    {
        private ObservableCollection<FoodUnit> foods;
        private ObservableCollection<AddedFoodView> mealFoodsList;
        private AddFoodItemViewModel addFoodItemViewModel;
        private IBlRouter _blRouter;
        private Meal meal;
        private String search;

        private async void OnFinish(Type obj)
        {

            await _blRouter.AddMeal(meal);
            EventAggregator.GetEvent<MealAddedEvent>().Publish();
            EventAggregator.GetEvent<OpenHomeEvent>().Publish();

        }

        private bool CanFinish(Type arg)
        {
            return true;
        }

        private void subscribe()
        {
            EventAggregator.GetEvent<BE.Events.AddFoodToMealEvent>().
                Subscribe(AddFoodToMeal);
            EventAggregator.GetEvent<BE.Events.SelectedDateChangedEvent>()
                .Subscribe(OnSelectedDateChanged);
        }

        private void AddFoodToMeal(AddFoodToMealEventArg obj)
        {
            meal.FoodsInMeals.Add(obj.Food);
            mealFoodsList.Add(new AddedFoodView()
            {
                Name = obj.Nutritions.FoodName,
                Quantity = obj.Food.Quantity,
                Calories = obj.Nutritions.NfCalories * obj.Food.Quantity,
            });
        }

        private void OnSelectedDateChanged(SelectedDateChangedEventArg obj)
        {
            meal.Date = obj.SelectedDate;
        }

        public SearchViewModel(IEventAggregator eventAggregator, 
            IMessageDialogService messageDialogService,
            DateTime date,
            IBlRouter blRouter)
        {
          
            mealFoodsList = new ObservableCollection<AddedFoodView>();

            EventAggregator = eventAggregator;
            _blRouter = blRouter;
            Search = "Milk";
            Foods = new ObservableCollection<FoodUnit>();
            meal = new Meal();
            meal.Date = date;

            FinishCommand = new DelegateCommand<Type>(OnFinish, CanFinish);

            subscribe();
        }

       

        public IEventAggregator EventAggregator { get;  }

        public ObservableCollection<FoodUnit> Foods
        {
            get
            {
                return foods;
            }
            set
            {
                foods = value;
                OnPropertyChanged();
            }
        }

     

        public String Search
        {
            get { return search; }
            set {
                search = value;
                OnPropertyChanged();
                SearchFoodsUnit();
            }
        }

        public async void SearchFoodsUnit()
        {
            var result = await new BL.BlRouter().GetSearchFood(Search);
            Foods.Clear();
            foreach (var food in result)
            {
                Foods.Add(food);
            }
        }

        public ICommand FinishCommand { get; }

        public Meal Meal
        {
            get { return meal; }
            set { meal = value; OnPropertyChanged(); }
        }

        public AddFoodItemViewModel AddFoodItemViewModel
        {
            get { return addFoodItemViewModel; }
            set { addFoodItemViewModel = value;OnPropertyChanged(); }
        }

        public ObservableCollection<AddedFoodView> MealFoodsList
        {
            get { return mealFoodsList; }

            set { mealFoodsList = value; OnPropertyChanged(); }
        }

    }

    public class AddedFoodView
    {
        public String Name { get; set; }

        public  int Quantity { get; set; }
        public double? Calories { get; set; }
    }

}
