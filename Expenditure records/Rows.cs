using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenditure_records
{
    class Rows
    {
        ObservableCollection<string> rows = new ObservableCollection<string>
        {
            "Buisness",
            "Scheta",
            "House",
            "Music",
            "Games",
            "Work",
            "Education",
            "Resort",
            "Communication",
            "Eat",
            "Walk"
        };
    }
}
