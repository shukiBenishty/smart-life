using System.Threading.Tasks;

namespace GUI.View.Services
{
  public interface IMessageDialogService
  {
        Task<MessageDialogResult> ShowOkCancelDialogAsync(string text, string title);
        Task ShowInfoDialogAsync(string text);

    }
}