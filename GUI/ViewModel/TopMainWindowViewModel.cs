using BE.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel
{
    public class TopMainWindowViewModel :ViewModelBase
    {
        private DateTime selectedDate;

        public TopMainWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SelectedDate = DateTime.Now;
            
        }

        private IEventAggregator _eventAggregator;

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set {
                selectedDate = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<SelectedDateChangedEvent>()
                    .Publish(new SelectedDateChangedEventArg(value));
            }
        }

    }
}
