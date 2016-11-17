using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Container.Special
{
    public class Class1
    {
        [Export("SpecialText")]
        public string SpecialText { get { return "This is a special string."; } }
    }
}
