using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Controls;
using MEFRecipes.Contracts;
using MEFRecipes.ViewModel;

namespace MEFRecipes
{
    [Export("Shell",typeof(UserControl))]
    public partial class MainPage : IPartImportsSatisfiedNotification
    {
        [Import]
        public MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
            set { DataContext = value; }
        }

        [Import]
        public IApplicationHost Host { get; set; }
    
        [Import("Plugin", AllowDefault = true, AllowRecomposition = true)]
        public UserControl Plugin { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var deploymentCatalog = new DeploymentCatalog("MefRecipes.Plugin.xap");
            Host.AddCatalog(deploymentCatalog);
            deploymentCatalog.DownloadAsync();
        }

        /// <summary>
        /// Called when a part's imports have been satisfied and it is safe to use.
        /// </summary>
        public void OnImportsSatisfied()
        {
            if (Plugin != null)
            {
                PluginContent.Content = Plugin; 
            }
        }
    }
}
