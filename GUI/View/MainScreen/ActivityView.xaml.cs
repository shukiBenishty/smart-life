using GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for ActivityView.xaml
    /// </summary>
    public partial class ActivityView : System.Windows.Controls.UserControl
    {
        private ActivityViewModel ViewModel { get; set; }
        public ActivityView()
        {
            InitializeComponent();
           /* ViewModel = new ActivityViewModel();
            DataContext = ViewModel;*/

        }

        
    }
}
