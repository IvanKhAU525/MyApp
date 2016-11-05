
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
        [DisplayName("№")]
        public double A { get; set; }
        [DisplayName("Категория")]
        public double B { get; set; }
        [DisplayName("Сумма, <<$>>")]
        public double C { get; set; }
        [DisplayName("Дата")]
        public DatePicker D { get; set; }
        [DisplayName("Удалить строку")]
        public Button E { get; set; }

        public CDataGrid(int a, int b, int c, DatePicker d, Button e)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.D = d;
            this.E = e;
        }
    }
}
