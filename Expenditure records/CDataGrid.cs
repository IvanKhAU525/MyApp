using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Expenditure_records
{
    public class CDataGrid: INotifyPropertyChanged
    {
        private int numeration;
        private Category category;
        private double sum;
        private DatePicker date;
            
        public CDataGrid() { }

        public int Numeration
        {
            get { return numeration; }

            set
            {
                numeration = value;
                OnPropertyChanged("Numeration");
            }
        }

        public Category Category
        {
            get { return category; }

            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }

        public double Sum
        {
            get { return sum; }

            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }

        public DatePicker Date
        {
            get; set;
        }

        public static implicit operator CDataGrid(int v)
        {
            CDataGrid temp = new CDataGrid();
            return temp;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
