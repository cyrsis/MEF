using System.ComponentModel.Composition;

namespace DataTransformer
{
    [Export(typeof(IDataTransform))]
    public class DataTransform : IDataTransform
    {
        [Import]
        public IDataProvider Input { get; set; }

        [ImportMany(AllowRecomposition = true)]
        public IDataExporter[] Output { get; set; }

        public void Transform()
        {
            var input = Input.FetchData();
            foreach (var exporter in Output)
            {
                exporter.ExportData(input);
            }
        }
    }
}