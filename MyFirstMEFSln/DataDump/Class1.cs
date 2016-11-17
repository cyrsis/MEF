using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using DataTransformer;

namespace DataDump
{
    [Export(typeof(IDataExporter))]
    public class Class1 : IDataExporter 
    {
        public void ExportData(DataInput data)
        {
            foreach(var row in data.Rows)
            {
                var x = 0;
                foreach(var column in data.ColumnNames)
                {
                    Console.WriteLine("Column {0} is {1}", column, row[x]);
                    x++;
                }
            }
        }
    }
}
