using System.ComponentModel.Composition;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MefRecipes.Plugin
{
    [Export("Plugin",typeof(UserControl))]
    public partial class SaveFile
    {
        [Import("Xml")]
        public string Xml { get; set; }

        private readonly SaveFileDialog _dialog;

        public SaveFile()
        {
            InitializeComponent();
            _dialog = new SaveFileDialog
                          {
                              DefaultExt = ".xml",
                              Filter = "XML Files|*.xml",
                              FilterIndex = 1
                          };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = _dialog.ShowDialog();

            if (dialogResult != true) return;

            byte[] xmlBytes = Encoding.UTF8.GetBytes(Xml);

            using (var fs = _dialog.OpenFile())
            {
                fs.Write(xmlBytes, 0, xmlBytes.Length);
                fs.Close();
            }
        }
    }
}
