using MyFirstMEF.Model;

namespace MyFirstMEF.Contracts
{
    public interface IDataExporter
    {            
        void ExportData(DataInput data);
    }
}