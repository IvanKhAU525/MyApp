
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Expenditure_records
{
    public class CDataGrid 
    {
        public uint Numeration { get; set; }
        public Category Category { get; set; }
        public double Sum { get; set; }
        public DatePicker Date { get; set; }
        public bool SeclectRow { get; set; }

        public CDataGrid() { }
    }
}
