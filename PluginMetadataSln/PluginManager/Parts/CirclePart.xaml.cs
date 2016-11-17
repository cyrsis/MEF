using System.ComponentModel.Composition;
using System.Windows.Controls;
using PluginManager.Contracts;

namespace PluginManager.Parts
{
    /// <summary>
    /// Interaction logic for CirclePart.xaml
    /// </summary>
    [ExportAsPlugin(Position = Positions.Header)]
    public partial class CirclePart : IPluginPart
    {
        public CirclePart()
        {
            InitializeComponent();
        }

        public UserControl Part
        {
            get { return this; }
        }
    }
}
