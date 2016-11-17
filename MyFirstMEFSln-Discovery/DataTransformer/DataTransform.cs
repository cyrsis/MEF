using System.ComponentModel.Composition;
using MyFirstMEF.Contracts;

namespace DataTransformer
{    
    public class DataTransform : IDataTransform
    {
        [Import]
        public IDataProvider Input { get; set; }

        [Import]
        public ILogger Logger { get; set; }

        [ImportMany(AllowRecomposition = true)]
        public IDataExporter[] Output { get; set; }

        public void Transform()
        {
            Logger.Log("Fetching data...");
            var input = Input.FetchData();
            foreach (var exporter in Output)
            {
                Logger.Log(string.Format("Exporting to: {0}", exporter));
                exporter.ExportData(input);
            }
        }
    }
}