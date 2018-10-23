using BE.Events;
using BL;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModel.google
{
    public class GoogleLoginViewModel : ViewModelBase, IGoogleLoginViewModel
    {
        private IBlRouter BlRouter;
        private IEventAggregator _eventAggregator;

        public GoogleLoginViewModel(IEventAggregator eventAggregator)
        {
            GoogleTryLogInCommand = new DelegateCommand<Type>(OnGoogleLogIn, CanGoogleLogIn);
            BlRouter = new BlRouter();
            _eventAggregator = eventAggregator;
        }

        private bool CanGoogleLogIn(Type arg)
        {
            return true;
        }

        private async void OnGoogleLogIn(Type obj)
        {
          await  BlRouter.MoveToGoogleLogin(_eventAggregator);
        }

        public ICommand GoogleTryLogInCommand { get; }
    }
}
