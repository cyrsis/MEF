using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightMEF.Exports;

namespace SilverlightMEF
{
    public partial class App : ILaunchInterface
    {
        private DeploymentCatalog _extension;

        [Import("Shell")]
        public UserControl Shell
        {
            get { return (UserControl) RootVisual; }
            set { RootVisual = value; }
        }
        
        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var catalog = new AggregateCatalog(new DeploymentCatalog());
            _extension = new DeploymentCatalog("SilverlightMEF.Extensions.xap");
            catalog.Catalogs.Add(_extension);
            var container = new CompositionContainer(catalog);
            CompositionHost.Initialize(container);
            container.ComposeExportedValue<ILaunchInterface>(this);
            CompositionInitializer.SatisfyImports(this);             
        }       

        private void Application_Exit(object sender, EventArgs e)
        {

        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }

        public void Launch()
        {
            _extension.DownloadCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(_extension_DownloadCompleted);
            _extension.DownloadAsync();
        }

        void _extension_DownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show(e.Error != null ? e.Error.Message : "Download complete.");
        }
    }
}
