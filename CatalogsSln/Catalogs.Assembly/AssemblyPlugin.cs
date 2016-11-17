using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Catalogs.Interface;

namespace Catalogs.Assembly
{
    [Export(typeof(IPlugin))]
    public class AssemblyPlugin : IPlugin 
    {
        public void DoSomething()
        {
            Console.WriteLine("Assembly plugin.");
        }
    }
}
