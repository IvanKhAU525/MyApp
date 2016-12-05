//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.Windows.Threading;
//using Microsoft.Research.DynamicDataDisplay;
//using System.Globalization;

//namespace Expenditure_records
//{
//    /// <summary>Sample that show rendering of data changing in time</summary>
//    public partial class Diagrams
//    {
//        ChartPlotter plotter = new ChartPlotter();
//        double phase = 0;
//        readonly double[] animatedX = new double[1000];
//        readonly double[] animatedY = new double[1000];
//        EnumerableDataSource<double> animatedDataSource = null;

//        /// <summary>Programmatically created header</summary>
//        Header chartHeader = new Header();

//        /// <summary>Text contents of header</summary>
//        TextBlock headerContents = new TextBlock();

//        /// <summary>Timer to animate data</summary>
//        readonly DispatcherTimer timer = new DispatcherTimer();

//        public Diagrams()
//        {
//            headerContents.FontSize = 24;
//            headerContents.Text = "Phase = 0.00";
//            headerContents.HorizontalAlignment = HorizontalAlignment.Center;
//            chartHeader.Content = headerContents;
//            plotter.Children.Add(chartHeader);
//        }


//    }
//}