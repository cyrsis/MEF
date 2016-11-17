using System.ComponentModel.Composition;

namespace UnderstandingParts
{
    public class PartTwo
    {
        [Export("SpecialText")]
        public string SpecialTextExport
        {
            get { return "Special Text"; }
        }

        [Export(typeof(object))]
        public string ObjectText
        {
            get { return "Object Text"; }
        }

        [ImportMany]
        public string[] TextArray { get; set; }
    }
}