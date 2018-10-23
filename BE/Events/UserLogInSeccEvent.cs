using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Events
{
    public class UserLogInSeccEvent : PubSubEvent<UserLogInSeccEventArg>
    {
        public UserLogInSeccEvent()
        {
        }
    }

    public class UserLogInSeccEventArg
    {
        public Guid Id { get; set; }
        public string Sub { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string GooglePlus { get; set; }
        public string Picture { get; set; }

    }
}
