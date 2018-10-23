using Prism.Events;
using System;

namespace BE.Events
{
    public class SelectedDateChangedEvent : PubSubEvent<SelectedDateChangedEventArg>
    {
        public void Subscribe(object onSelectedDateChanged)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedDateChangedEventArg
    {
        public SelectedDateChangedEventArg(DateTime selectedDate)
        {
            SelectedDate = selectedDate;
        }

        public DateTime SelectedDate { get; set; }
    }
}
