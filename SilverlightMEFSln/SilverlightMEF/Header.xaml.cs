using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SilverlightMEF
{
    public partial class Header
    {
        [Import("HeaderText")]
        public string HeaderTextString
        {
            get { return HeaderText.Text; }
            set { HeaderText.Text = value; }
        }

        public Header()
        {
            InitializeComponent();
            if (DesignerProperties.IsInDesignTool)
            {
                HeaderTextString = "Design-time text";
            }
            else
            {
                CompositionInitializer.SatisfyImports(this);
            }
        }
    }
}