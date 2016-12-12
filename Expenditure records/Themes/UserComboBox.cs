using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Expenditure_records.Themes
{
    partial class UserComboBox : ResourceDictionary
    {
        string ItemContent;
        static uint grid = 0;
        static DependencyObject parentObject;
        private Grid Grid2Level;
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
                    (sender as TextBox).Text = "";

                    DependencyObject parentObject = VisualTreeHelper.GetParent(sender as TextBox);
                    parentObject = VisualTreeHelper.GetChild(parentObject, 0);
                    ComboBoxItem item = (parentObject as StackPanel).Children[(parentObject as StackPanel).Children.Count-1] as ComboBoxItem;
                    Grid2Level = FindParent<Grid>(sender as TextBox);
                    (Grid2Level.Children[1] as ContentPresenter).Content = item.Content;
                }
            }
        }

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            parentObject = LogicalTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null)
                return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
                if (grid != 0)
                {
                    grid = 0;
                    return parent;
                }
                else
                {
                    grid++;
                    return FindParent<T>(parentObject);
                }
            else
            {
                return FindParent<T>(parentObject);
            }
        }

        private void ItemDelete(object sender, RoutedEventArgs e)
        {
            int index = 0;
            if (ControlPanel.ComboCollection.IndexOf(ItemContent) != -1)
                index = ControlPanel.ComboCollection.IndexOf(ItemContent);
            ControlPanel.ComboCollection.RemoveAt(index);

            //update item in string
            //ComboBoxItem item = (parentObject as StackPanel).Children[(parentObject as StackPanel).Children.Count-Count] as ComboBoxItem;
            //(Grid2Level.Children[1] as ContentPresenter).Content = item.Content;
        }

        private void SelectedItem(object sender, RoutedEventArgs e)
        {
            ItemContent = (sender as ContentPresenter).Content.ToString();
        }
    }
}
