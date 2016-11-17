using System;
using System.Collections.Generic;
using System.Linq;
using MyFirstMEF.Model;

namespace MyFirstMEF.Test
{
    public static class DataInputEqualityExtension
    {
        public static bool IsEqualTo(this DataInput source, DataInput target)
        {
            return new DataInputEquality().Equals(source, target);
        }
    }

    public class DataInputEquality : IEqualityComparer<DataInput>
    {
        public bool Equals(DataInput x, DataInput y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            if (x.ColumnNames.Count != y.ColumnNames.Count)
            {
                return false;
            }

            if (x.ColumnNames.Where((t, idx) => !t.Equals(y.ColumnNames[idx])).Any())
            {
                return false;
            }

            if (x.Rows.Count != y.Rows.Count)
            {
                return false;
            }

            var rowNumber = 0;

            foreach(var row in x.Rows)
            {
                for (var idx = 0; idx < row.Count; idx++)
                {
                    if (!row[idx].Equals(y.Rows[rowNumber][idx]))
                    {
                        return false;
                    }
                }
                rowNumber++;
            }

            return true;
        }

        public int GetHashCode(DataInput obj)
        {
            return obj.GetHashCode();
        }
    }
}