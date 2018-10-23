using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Event
{
   public class AfterSaveAddFoodEvent : PubSubEvent<AfterSaveAddFoodEventArg>
    {
    }

    public class AfterSaveAddFoodEventArg
    {
        public string ViewModelName { get; set; }
    }
}
