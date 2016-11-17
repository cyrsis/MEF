using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace LifeManagementSilverlight
{
    public partial class MainPage
    {
        [Import]
        public IKeyProvider Key1 { get; set; }

        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        public IKeyProvider Key2 { get; set; }

        [Import]
        public IKeyProvider Key3 { get; set; }

        [Import]
        public ExportFactory<IKeyProvider> KeyFactory { get; set; }
        
        public MainPage()
        {
            InitializeComponent();
            Loaded += new System.Windows.RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            CompositionInitializer.SatisfyImports(this);
            var list = new List<string> {Key1.Key, Key2.Key, Key3.Key};

            for (var x = 0; x < 5; x++ )
            {
                var key = KeyFactory.CreateExport().Value;
                list.Add(key.Key);
            }

                Keys.ItemsSource = list;
        }
    }
}
