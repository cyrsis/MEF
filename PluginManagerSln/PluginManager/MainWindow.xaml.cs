using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Windows;
using PluginManager.Contracts;
using PluginManager.Parts;

namespace PluginManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IPartImportsSatisfiedNotification
    {
        private AggregateCatalog _mainCatalog;
        private CompositionContainer _mainContainer;
        private DirectoryCatalog _directoryCatalog;

        private object _lastCollection;
        
        [Import(AllowDefault=true,AllowRecomposition = true)]
        public ILogger Logger { get; set; }

        [ImportMany(AllowRecomposition = true)]
        public IPluginPart[] Parts { get; set; }        

        private void _Log(string logText)
        {
            if (Logger != null)
            {
                Logger.Log(logText);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += _MainWindowLoaded;
        }

        void _MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _Log("Main window is loaded.");

                _mainCatalog = new AggregateCatalog(new AssemblyCatalog(GetType().Assembly));

                _Log("Catalog created.");

                _mainContainer = new CompositionContainer(_mainCatalog);

                _Log("Container created.");

                _mainContainer.ComposeParts(this);

                _Log("Container composed.");                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var compositionBatch = new CompositionBatch();
                compositionBatch.AddExportedValue<IPluginPart>(new DynamicPart(new SquarePart()));
                compositionBatch.AddExportedValue<IPluginPart>(new DynamicPart(new TextPart()));
                _mainContainer.Compose(compositionBatch);

                if (_directoryCatalog == null)
                {
                    _directoryCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory());
                    _mainCatalog.Catalogs.Add(_directoryCatalog);
                }
                else
                {
                    _directoryCatalog.Refresh();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Called when a part's imports have been satisfied and it is safe to use.
        /// </summary>
        public void OnImportsSatisfied()
        {
            if (_lastCollection != null)
            {
                Debug.WriteLine("Old collection == new collection: {0}",
                    ReferenceEquals(_lastCollection, Parts));
            }

            _lastCollection = Parts;

            Panel.Children.Clear();

            foreach (var plugin in Parts)
            {
                _Log(string.Format("Added part {0}", plugin.Part.GetType().FullName));
                Panel.Children.Add(plugin.Part);
            }
        }
    }
}
