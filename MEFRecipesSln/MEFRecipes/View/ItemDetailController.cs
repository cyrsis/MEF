using System.ComponentModel.Composition;
using System.Windows.Controls;
using MEFRecipes.Contracts;

namespace MEFRecipes.View
{
    [Export(typeof(IDetailWindow))]
    public class ItemDetailController : IDetailWindow 
    {
        [Import("Detail")]
        public ExportFactory<ChildWindow> Factory { get; set; }

        public void Open()
        {
            Factory.CreateExport().Value.Show();
        }
    }
}