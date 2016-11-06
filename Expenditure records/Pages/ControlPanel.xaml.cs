using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
        DatePicker dp = new DatePicker();
        Int16 index;
        public ObservableCollection<CDataGrid> TestProperty { get; set; } = new ObservableCollection<CDataGrid>();

        public ControlPanel()
        {
            DataContext = this;
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var displayName = GetPropertyDisplayName(e.PropertyDescriptor);

            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }
            switch (displayName)
            {
                case "№":
                    e.Column.MinWidth = 35;
                    break;
                case "Категория":
                    e.Column.MinWidth = 120;
                    break;
                case "Сумма, <<$>>":
                    e.Column.MinWidth = 160;
                    break;
                case "Дата":
                    e.Column.MinWidth = 60;
                    break;

            }
        }

      public static string GetPropertyDisplayName(object descriptor)
        {
            var pd = descriptor as PropertyDescriptor;

            if (pd != null)
            {
                // Check for DisplayName attribute and set the column header accordingly
                var displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;

                if (displayName != null && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }

            }
            else
            {
                var pi = descriptor as PropertyInfo;

                if (pi != null)
                {
                    // Check for DisplayName attribute and set the column header accordingly
                    Object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        var displayName = attributes[i] as DisplayNameAttribute;
                        if (displayName != null && displayName != DisplayNameAttribute.Default)
                        {
                            return displayName.DisplayName;
                        }
                    }
                }
            }
            return null;
        }

        private void Button_Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TestProperty.Add(new CDataGrid(0, 0, 0, dp));
            AddButtonsToWrapPanel();
        }

        private void AddButtonsToWrapPanel()
        {
            Button but = new Button();
            ImageBrush imbr = new ImageBrush();
            imbr.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri("Images/delete.png", UriKind.Relative));
            but.Background = imbr;
            WrapPanel.Children.Add(but);
            but.Tag = index;
            index++;
            but.Height = 20;
            but.Width = 50;
            but.Click += new RoutedEventHandler(Button_Click);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TestProperty.RemoveAt(0);
                WrapPanel.Children.Remove(sender as Button);
                sender = null;
            }
            catch (System.ArgumentOutOfRangeException)
            {
            }
        }
    }
}
