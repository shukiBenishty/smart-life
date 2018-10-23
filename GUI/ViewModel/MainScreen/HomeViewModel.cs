using BL;
using Prism.Events;
using System.Threading.Tasks;

namespace GUI.ViewModel
{
    public class HomeViewModel : ViewModelBase, IHomeViewModel
    {
        private IEventAggregator _eventAggregator;
        private IBlRouter _blRouter;

        public HomeViewModel(IEventAggregator eventAggregator,
              IActivityViewModel activityViewModel,
            IBlRouter blRouter)
        {
            ActivityViewModel = activityViewModel;
            _eventAggregator = eventAggregator;
            _blRouter = blRouter;
        }

        public IActivityViewModel ActivityViewModel { get; }

        public Task LoadAsync()
        {
            return null;
        }
    }
}
