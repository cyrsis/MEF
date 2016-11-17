using System;
using System.ComponentModel.Composition;
using MyFirstMEF.Contracts;
using MyFirstMEF.Model;

namespace DataTransformer
{
    [Export(typeof(IDataExporter))]
    public class JsonExporter : IDataExporter
    {
        public void ExportData(DataInput data)
        {
            Console.Write("{\"data\": [ ");
            var first = true;
            foreach(var row in data.Rows)
            {
                if (first)
                {
                    first = false;                    
                }
                else
                {
                    Console.Write(", ");
                }
                Console.Write("{");

                for (var x = 0; x < data.ColumnNames.Count; x++ )
                {
                    Console.Write(" \"{0}\" : \"{1}\"", data.ColumnNames[x], row[x]);
                    if (x < data.ColumnNames.Count-1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.Write("}");
            }
            Console.WriteLine("]}");
        }
    }
}