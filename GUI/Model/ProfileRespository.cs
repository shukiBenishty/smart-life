using BE.Events;
using BL;
using Prism.Events;
using System;

namespace GUI.Model
{
    public class ProfileRespository
    {
        private IEventAggregator _eventAggregator;

        public ProfileRespository(IBlRouter blRouter,
            IEventAggregator eventAggregator)
        {
            BlRouter = blRouter;
            Init();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<UserLogoutEvent>()
                .Subscribe(UserLogout);
        }

        private void UserLogout()
        {
            GetCurrentProfileId = new Guid();
        }

        private async void Init()
        {
            GetCurrentProfileId = await BlRouter.GetCurrentAccountId();
        }

        public Guid GetCurrentProfileId { get; private set; }

        public IBlRouter BlRouter { get; }
    }
}
