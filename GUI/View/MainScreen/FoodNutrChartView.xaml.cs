using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for FoodNutrChartView.xaml
    /// </summary>
    public partial class FoodNutrChartView : UserControl, INotifyPropertyChanged
    {
        private SeriesCollection _seriesCollectionyVar;
        private Func<double, string> _formatter;
        private string[] _labels;

        public FoodNutrChartView()
        {
            InitCart();
        }

        private void InitCart()
        {
            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "test",
                      Values = new ChartValues<double> { 10, 20,30,40 }
                    //Values = new ChartValues<double> { ConverToInt(food.NfCalories), ConverToInt(food.NfProtein)
                    //, ConverToInt(food.NfTotalFat), ConverToInt(food.NfCholesterol) }
                }
            };


            SeriesCollection.Add(new RowSeries
            {
                Title = "Daily goal",
                //Values = new ChartValues<double> { goals.CaloriesConsume, goals.ProteinConsume, goals.TotalfatConsume, goals.CholesterolConsume }
                Values = new ChartValues<double> {100,100,100,100}
            });


            Labels = new[] { "Calories", "Frotein", "Fat", "Cholesterol" };
            Formatter = value => value.ToString("N");
        }

        public void Update(SeriesCollection seriesCollectionyVar, Func<double, string> formatter, string[] labels)
        {
            InitializeComponent();
            _seriesCollectionyVar = seriesCollectionyVar;
            _formatter = formatter;
            _labels = labels;
            DataContext = this;
        }



        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollectionyVar; }
            set { _seriesCollectionyVar = value; OnPropertyChanged(); }
        }

        public string[] Labels
        {
            get { return _labels; }
            set { _labels = value; OnPropertyChanged(); }
        }

        public Func<double, string> Formatter
        {
            get { return _formatter; }
            set { _formatter = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected  void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
