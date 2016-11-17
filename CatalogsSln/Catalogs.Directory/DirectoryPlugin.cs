using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Catalogs.Interface;

namespace Catalogs.Directory
{
    [Export(typeof(IPlugin))]
    public class DirectoryPlugin : IPlugin 
    {
        public void DoSomething()
        {
            Console.WriteLine("Directory plugin.");
        }
    }
}
