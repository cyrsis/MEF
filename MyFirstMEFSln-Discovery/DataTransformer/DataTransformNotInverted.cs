namespace DataTransformer
{
    public class DataTransformNotInverted  
    {
        private readonly CsvDataProvider _provider = new CsvDataProvider();

        private readonly XmlExporter _xml = new XmlExporter();
        private readonly JsonExporter _json = new JsonExporter();

        public void Transform()
        {
            var input = _provider.FetchData();
            _xml.ExportData(input);            
            _json.ExportData(input);
        }
    }
}