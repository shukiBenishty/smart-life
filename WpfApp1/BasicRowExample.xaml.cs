using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace Wpf.CartesianChart.Basic_Bars
{
    public partial class BasicRowExample : UserControl
    {
        public BasicRowExample()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "This Food",
                    Values = new ChartValues<double> { 10, 50,0, 39 }
                }
            };

            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new RowSeries
            {
                Title = "Desntion",
                Values = new ChartValues<double> { 11, 56,100 ,42 }
            });

            //also adding values updates and animates the chart automatically
          

            Labels = new[] { "Cal", "Proton", "fat", "carbon" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

    }
}