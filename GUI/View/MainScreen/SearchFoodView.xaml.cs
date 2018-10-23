using GUI.ViewModel;
using GUI.ViewModel.MainScreen;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for SearchFoodView.xaml
    /// </summary>
    public partial class SearchFoodView : System.Windows.Controls.UserControl
    {
        private Expander theLastExpander;
        private SearchViewModel _searchViewModel;
        public SearchFoodView(SearchViewModel  searchViewModel)
        {
            _searchViewModel = searchViewModel;
            InitializeComponent();
            DataContext = _searchViewModel;
           
        }

       

        private void Expander_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           if( theLastExpander == sender as Expander)
            {
                return;
            }
            if (theLastExpander != null )
            {
                theLastExpander.IsExpanded = false;
            }
            theLastExpander = sender as Expander;
            _searchViewModel.AddFoodItemViewModel = new AddFoodItemViewModel(((sender as Expander).Tag as string), _searchViewModel.EventAggregator);
        }
    }
}
