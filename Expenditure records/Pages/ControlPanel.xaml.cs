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

namespace Expenditure_records
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class ControlPanel : Page
    {
        List<Button> lstOfBut = new List<Button>();
        DatePicker dp = new DatePicker();
        Int16 clk;
        public ObservableCollection<CDataGrid> TestProperty { get; set; } = new ObservableCollection<CDataGrid>();

        public ControlPanel()
        {
            dp.
            DataContext = this;
            TestProperty.Add(new CDataGrid(12, 213, 23, dp));
            TestProperty.Add(new CDataGrid(12, 213, 23, dp));

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
                case "Сумма, <<.!.>>":
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
        }

        private void Button_Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                TestProperty.RemoveAt(0);
            }
            catch (System.ArgumentOutOfRangeException)
            {
            }
        }

        private void ControlPanel_OnInitialized(object sender, EventArgs e)
        {
            var buttonTemplate = new FrameworkElementFactory(typeof(Button));
            buttonTemplate.AddHandler(
                    Button.ClickEvent,
                    new RoutedEventHandler((o, events) =>
                    {
                        var btn = o as Button;

                    })
                    );
            MyData.Columns.Add(
                new DataGridTemplateColumn()
                {
                    Header = "123",
                    CellTemplate = new DataTemplate(),
                    DisplayIndex = 4
                }
                );
        }
    }
}
