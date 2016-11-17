using System.Collections.Generic;

namespace DataTransformer
{
    public class DataInput
    {
        public IList<string> ColumnNames { get; set; }
        public IList<IList<string>> Rows { get; set; }
    }
}