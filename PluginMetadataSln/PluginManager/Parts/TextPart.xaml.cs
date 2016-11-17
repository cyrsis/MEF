using System.ComponentModel.Composition;
using System.Windows.Controls;
using PluginManager.Contracts;

namespace PluginManager.Parts
{
    /// <summary>
    /// Interaction logic for TextPart.xaml
    /// </summary>
    [ExportAsPlugin(Position = Positions.Footer)]
    public partial class TextPart : IPluginPart
    {
        public TextPart()
        {
            InitializeComponent();
        }

        public UserControl Part
        {
            get { return this; }
        }
    }
}
