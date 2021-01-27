using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chart_Sqlite_Sample
{
    public class ChartDataModel
    {
        [PrimaryKey]
        public string XValue { get; set; }
        public double YValue { get; set; }
    }
}
