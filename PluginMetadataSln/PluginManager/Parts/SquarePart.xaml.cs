using System.ComponentModel.Composition;
using System.Windows.Controls;
using PluginManager.Contracts;

namespace PluginManager.Parts
{
    /// <summary>
    /// Interaction logic for SquarePart.xaml
    /// </summary>
    [Export(typeof(IPluginPart))]
    public partial class SquarePart : IPluginPart 
    {
        public SquarePart()
        {
            InitializeComponent();
        }

        public UserControl Part
        {
            get { return this; }
        }
    }
}
