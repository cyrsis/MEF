using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Windows.Controls;
using MEFRecipes.Contracts;

namespace MEFRecipes
{
    public partial class App : IApplicationHost
    {
        private readonly AggregateCatalog _mainCatalog;
        private readonly CompositionContainer _container; 

        [Import("Shell")]
        public UserControl Shell
        {
            get { return (UserControl) RootVisual; }
            set { RootVisual = value; }
        }

        public App()
        {            
            InitializeComponent();
            _mainCatalog = new AggregateCatalog(new DeploymentCatalog());
            _container = new CompositionContainer(_mainCatalog);
            _container.ComposeExportedValue<IApplicationHost>(this);
            CompositionHost.Initialize(_container);
            CompositionInitializer.SatisfyImports(this);
        }

        public void AddCatalog(ComposablePartCatalog catalog)
        {
            _mainCatalog.Catalogs.Add(catalog);
        }

        public void ComposeExport<T>(T export)
        {
            _container.ComposeExportedValue(export);
        }
    }
}
