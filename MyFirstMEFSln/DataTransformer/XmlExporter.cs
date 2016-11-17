using System;
using System.ComponentModel.Composition;
using System.Xml.Linq;

namespace DataTransformer
{
    [Export(typeof(IDataExporter))]
    public class XmlExporter : IDataExporter 
    {
        public void ExportData(DataInput data)
        {
            var root = new XElement("data");
            foreach(var row in data.Rows)
            {
                var node = new XElement("row");
                for(var x = 0; x < data.ColumnNames.Count; x++)
                {
                    var attribute = new XAttribute(data.ColumnNames[x], row[x]);
                    node.Add(attribute);
                }
                root.Add(node);
            }

            Console.WriteLine(root.ToString());
        }
    }
}