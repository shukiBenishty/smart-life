using System.Threading.Tasks;

namespace GUI.ViewModel
{
    public interface IAddMenuViewModel
    {
        Task LoadAsync(int id);
    }
}