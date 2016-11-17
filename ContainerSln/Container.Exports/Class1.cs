using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Container.Exports
{
    public class Class1
    {
        [Export]
        public string ExportedString
        {
            get { return "This is an exported string."; }
        }        
    }
}
