using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace SilverlightMEF
{
    [Export("Shell",typeof(UserControl))]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
