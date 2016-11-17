using System.ComponentModel.Composition;

namespace SilverlightMEF.Exports
{
    public class Class1
    {
        [Export("HeaderText")]
        public string HeaderText { get { return "This is the header text."; } }

        [Export("ListItem")]
        public string ListItem1 { get { return "This is list item 1"; } }
    }

    
}
