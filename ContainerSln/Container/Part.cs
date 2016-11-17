using System.ComponentModel.Composition;

namespace Container
{
    public class Part
    {
        [Export]
        public string Text1
        {
            get { return "This is the first text."; }
        }

        [Export]
        public string Text2
        {
            get { return "This is some more text."; }
        }
    }
}