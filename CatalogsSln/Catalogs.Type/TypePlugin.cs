using System;
using Catalogs.Interface;

namespace Catalogs.Type
{
    public class TypePlugin : IPlugin 
    {
        public void DoSomething()
        {
            Console.WriteLine("Type plugin.");
        }
    }
}
