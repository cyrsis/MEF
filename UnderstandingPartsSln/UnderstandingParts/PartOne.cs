using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace UnderstandingParts
{
    public class PartOne
    {
        [Export]
        public string SimpleText
        {
            get { return "Simple Text"; }
        }

        [Export("MoreSimpleText")]
        [Export]
        public string MoreSimpleText
        {
            get { return "More Simple Text."; }
        }

        [Import]
        public object ObjectImport { get; set; }

        [Import("SpecialText")]
        public string SpecialTextImport { get; set; }
    }
}
