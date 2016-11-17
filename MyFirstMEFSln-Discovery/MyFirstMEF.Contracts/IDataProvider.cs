using MyFirstMEF.Model;

namespace MyFirstMEF.Contracts
{
    public interface IDataProvider
    {       
        DataInput FetchData();
    }
}
