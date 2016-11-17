using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using PluginManager.Contracts;

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

        [Import(AllowDefault = true, AllowRecomposition = true)]
        public ILogger Logger { get; set; }

        [ImportMany(AllowRecomposition = true)]
        public Lazy<IPluginPart,IPluginMetadata>[] Parts { get; set; }

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

        private void _MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _Log("Main window is loaded.");

                _mainCatalog = new AggregateCatalog(new AssemblyCatalog(GetType().Assembly));

                _Log("Catalog created.");

                _mainContainer = new CompositionContainer(_mainCatalog);

                _directoryCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory());
                _mainCatalog.Catalogs.Add(_directoryCatalog);

                _Log("Container created.");

                _mainContainer.ComposeParts(this);

                _Log("Container composed.");
            }
            catch (Exception ex)
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

            HeaderPanel.Children.Clear();
            FooterPanel.Children.Clear();

            foreach (var plugin in Parts)
            {
                var position = plugin.Metadata.Position;
                
                if (position.Equals(Positions.Header))
                {
                    HeaderPanel.Children.Add(plugin.Value.Part);
                }
                else
                {
                    FooterPanel.Children.Add(plugin.Value.Part);
                }
            }
        }
    }
}