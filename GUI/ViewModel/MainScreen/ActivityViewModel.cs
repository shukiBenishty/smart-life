using BE.Events;
using BE.Models;
using BL;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel
{
    public class ActivityViewModel : ViewModelBase, IActivityViewModel
    {

        private BL.IBlRouter _blRouter;
        private IEventAggregator _eventAggregator;
        private ObservableCollection<Activity> activityList;
        private DateTime dateTime;
      

        public ActivityViewModel(IEventAggregator eventAggregator, IBlRouter blRouter)
        {

            _blRouter = blRouter;
            _eventAggregator = eventAggregator;
            ActivityList = new ObservableCollection<Activity>();

            _eventAggregator.GetEvent<BE.Events.SelectedDateChangedEvent>()
                .Subscribe(SelectedDateChanged);
            _eventAggregator.GetEvent<BE.Events.MealAddedEvent>()
                .Subscribe(LoadAsync);
            
        }

        private void SelectedDateChanged(SelectedDateChangedEventArg obj)
        {
            dateTime = obj.SelectedDate;
            LoadAsync();
        }

        public async void LoadAsync()
        {

            try
            {
                var result = await _blRouter.GetActivityListAsync(dateTime);
                ActivityList.Clear();
                foreach (var item in result)
                {
                    ActivityList.Add(item);
                }
            }
            catch (Exception e)
            {

               // no action 
            }
           



        }


      
       


        public ObservableCollection<Activity> ActivityList
        {
            get {
             
                return activityList;

            }
            set {
                activityList = value;
                OnPropertyChanged();
            }
        }

    }
}
