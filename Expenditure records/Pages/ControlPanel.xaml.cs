using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Expenditure_records
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class ControlPanel : Page
    {
        ObservableCollection<CDataGrid> list = null;
        DatePicker dp = new DatePicker();
        public ControlPanel()
        {
            InitializeComponent();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            int number = MyData.Items.Count;
            if (list == null)
            {
                
                list = new ObservableCollection<CDataGrid>();
                MyData.ItemsSource = list;
                MyData.CanUserAddRows = false;
            }
            list.Add(new CDataGrid() { Numeration = number, Category = Category.Scheta, Date = DateTime.UtcNow});
            number++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = MyData.Items.IndexOf(MyData.CurrentItem);
            list.RemoveAt(currentRowIndex);
            RecalculationOfNumbers();
        }

        private void RecalculationOfNumbers()
        {
            int i = 0;
            foreach (var ob in list)
            {
                ob.Numeration = i;
                i++;
            }
        }
    }
}
