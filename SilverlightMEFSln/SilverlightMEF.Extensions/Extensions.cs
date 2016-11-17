using System.ComponentModel.Composition;

namespace SilverlightMEF.Extensions
{
    public class Extensions
    {
        [Export("ListItem")]
        public string ListItem2 { get { return "This is the extended list item."; } }
    }
}