using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;
using MyFirstMEF.Contracts;
using MyFirstMEF.Model;

namespace DataTransformer
{
    [Export(typeof(IDataProvider))]
    public class CsvDataProvider : IDataProvider
    {
        public DataInput FetchData()
        {
            var input = new DataInput();
            var path = typeof (CsvDataProvider).FullName.Replace(typeof (CsvDataProvider).Name, "Planets.txt");
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
            {
                using (var reader = new StreamReader(stream))
                {
                    var firstLine = reader.ReadLine();
                    var columns = firstLine.Split(',');
                    input.ColumnNames = new List<string>(columns);
                    var nextLine = reader.ReadLine();
                    input.Rows = new List<IList<string>>();
                    while (!reader.EndOfStream)
                    {
                        var data = nextLine.Split(',');
                        var dataList = new List<string>(data);
                        input.Rows.Add(dataList);
                        nextLine = reader.ReadLine();
                    }
                }
            }
            return input;
        }
    }
}