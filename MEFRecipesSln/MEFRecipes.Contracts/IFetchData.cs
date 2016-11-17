using System;
using System.Collections;

namespace MEFRecipes.Contracts
{
    public interface IFetchData
    {
        void FetchData(Action<IEnumerable> list, Action<string> data);
    }
}