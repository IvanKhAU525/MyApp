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
using Expenditure_records.Themes;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace Expenditure_records
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class ControlPanel : Page
    {
        public  ObservableCollection<CDataGrid> CDataGridList { get;  set; } = null;
        public string SelectedItem { get; set; } = null;
        private static ObservableCollection<string> combocollection = new ObservableCollection<string> { "1", "2", "3", "4", "5"};
        Regex regEx = new Regex(@"[^\s]");
        public static ObservableCollection<string> ComboCollection
        {
            get { return combocollection; }

            set
            {
                combocollection.Add(value.ToString());
                //OnPropertyChanged("ComboCollection");
            }
        }
        DatePicker dp = new DatePicker();
        public ControlPanel()
        {
            InitializeComponent();
            UserComboBox.DataGrid = MyData;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            int number = MyData.Items.Count;
            if (CDataGridList == null)
            {
                
                CDataGridList = new ObservableCollection<CDataGrid>();
                MyData.ItemsSource = CDataGridList;
                MyData.CanUserAddRows = false;
            }
            CDataGridList.Add(new CDataGrid() { Numeration = number, Category = Category.Scheta, Date = DateTime.UtcNow});
            number++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = MyData.Items.IndexOf(MyData.CurrentItem);
            CDataGridList.RemoveAt(currentRowIndex);
            RecalculationOfNumbers();
        }

        private void RecalculationOfNumbers()
        {
            int i = 0;
            foreach (var ob in CDataGridList)
            {
                ob.Numeration = i;
                i++;
            }
        }
    }
}
