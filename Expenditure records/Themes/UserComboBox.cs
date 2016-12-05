using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Expenditure_records.Themes
{
    partial class UserComboBox : ResourceDictionary
    {
        Regex regEx = new Regex(@"[^\s]");

        public static DataGrid DataGrid
        {
            get; set;
        }

        public UserComboBox()
        {
            InitializeComponent();
        }
        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (regEx.IsMatch((sender as TextBox).Text))
                {
                    ControlPanel.ComboCollection.Add((sender as TextBox).Text);
                    var comboBox = FindParent<ComboBox>(sender as TextBox);
                    comboBox.SelectedItem = (sender as TextBox).Text;
                }
            }
        }
        private T FindParent<T>(DependencyObject child)

where T : DependencyObject
        {
            T parent = VisualTreeHelper.GetParent(child) as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parent);
        }
    }
}
