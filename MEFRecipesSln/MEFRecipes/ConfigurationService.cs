using System;
using System.ComponentModel.Composition;
using System.Windows;
using MEFRecipes.Contracts;

namespace MEFRecipes
{
    public class ConfigurationService : IConfiguration, IApplicationService, IApplicationLifetimeAware
    {
        [Import]
        public IApplicationHost Host { get; set; }

        public Uri FeedUri { get; private set; }

        public string Mode { get; private set; }

        /// <summary>
        /// Called by an application in order to initialize the application extension service.
        /// </summary>
        /// <param name="context">Provides information about the application state. </param>
        public void StartService(ApplicationServiceContext context)
        {
            if (!context.ApplicationInitParams.ContainsKey("feedUri"))
            {
                throw new Exception("Must be configured with the feed.");
            }

            var mode = context.ApplicationInitParams.ContainsKey("mode")
                           ? context.ApplicationInitParams["mode"]
                           : "Mock";

            if (string.IsNullOrEmpty(mode))
            {
                mode = "Mock";
            }

            Mode = mode;

            FeedUri = new Uri(context.ApplicationInitParams["feedUri"], UriKind.Absolute);
        }

        /// <summary>
        /// Called by an application in order to stop the application extension service. 
        /// </summary>
        public void StopService()
        {
            FeedUri = null;
        }

        /// <summary>
        /// Called by an application immediately before the <see cref="E:System.Windows.Application.Startup"/> event occurs.
        /// </summary>
        public void Starting()
        {
            return;
        }

        /// <summary>
        /// Called by an application immediately after the <see cref="E:System.Windows.Application.Startup"/> event occurs.
        /// </summary>
        public void Started()
        {
            CompositionInitializer.SatisfyImports(this);
            Host.ComposeExport<IConfiguration>(this);
        }

        /// <summary>
        /// Called by an application immediately before the <see cref="E:System.Windows.Application.Exit"/> event occurs. 
        /// </summary>
        public void Exiting()
        {
            return;
        }

        /// <summary>
        /// Called by an application immediately after the <see cref="E:System.Windows.Application.Exit"/> event occurs. 
        /// </summary>
        public void Exited()
        {
            return;
        }
    }
}