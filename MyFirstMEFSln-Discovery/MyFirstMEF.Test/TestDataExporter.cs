using System;
using MyFirstMEF.Contracts;
using MyFirstMEF.Model;

namespace MyFirstMEF.Test
{
    public class TestDataExporter : IDataExporter 
    {
        public DataInput Input { get; set; }

        public void ExportData(DataInput data)
        {
            Input = data;
        }
    }
}