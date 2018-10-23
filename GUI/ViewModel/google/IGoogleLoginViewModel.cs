using System.Windows.Input;

namespace GUI.ViewModel.google
{
    public interface IGoogleLoginViewModel
    {
        ICommand GoogleTryLogInCommand { get; }
    }
}