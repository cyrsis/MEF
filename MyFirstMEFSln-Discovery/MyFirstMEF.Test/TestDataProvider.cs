using MyFirstMEF.Contracts;
using MyFirstMEF.Model;

namespace MyFirstMEF.Test
{
    public class TestDataProvider : IDataProvider
    {
        private readonly DataInput _input;

        public TestDataProvider(DataInput input)
        {
            _input = input;
        }

        public DataInput FetchData()
        {
            return _input;
        }
    }
}