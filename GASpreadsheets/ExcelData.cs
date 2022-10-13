using Lib.Genetics;
using Lib.Tsp;
using System;

namespace GASpreadsheets
{
    public class ExcelData
    {
        public string Title { get; set; }
        public Graph Graph { get; set; }
        public GASetup Setup { get; set; }
        public GAResult Result { get; set; }

        public ExcelData()
        {
        }
    }
}
