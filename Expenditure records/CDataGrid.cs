using System;
using System.Collections.ObjectModel;
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
        private DateTime? date;
        //private ObservableCollection<string> combocollection = new ObservableCollection<string> {"123","456","789" };
            
        public CDataGrid() { }

        //public ObservableCollection<string> ComboCollection
        //{
        //    get { return combocollection; }

        //    set
        //    {
        //        combocollection.Add(value.ToString());
        //        //OnPropertyChanged("ComboCollection");
        //    }
        //}

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

        public DateTime? Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value.Equals(date)) return;
                date = value;
                OnPropertyChanged();
            }
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
