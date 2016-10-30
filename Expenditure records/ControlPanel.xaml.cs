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

namespace Expenditure_records
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class ControlPanel : Page
    {
        public ControlPanel()
        {
            IEnumerable<CDataGrid> result = new List<CDataGrid>() { new CDataGrid(1, 1, 1, 1) };
          //  MyDataGrid.ItemsSource = result;
        }
    }
}
