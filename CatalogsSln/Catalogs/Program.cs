using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using Catalogs.Assembly;
using Catalogs.Interface;

namespace Catalogs
{    
    class Program
    {
        [ImportMany]
        public List<IPlugin> Plugins { get; set; }

        private AggregateCatalog _catalog;
        
        static void Main(string[] args)
        {
            var p = new Program {Plugins = new List<IPlugin>()};
            p.Run();
        }

        /// <summary>
        ///     Run method
        /// </summary>
        /// <remarks>
        ///     You must copy the out put of the Catalogs.Directory to the working directory (bin/debug) for that plugin
        ///     to appear
        /// </remarks>
        private void Run()
        {
            _catalog = new AggregateCatalog();

            var assemblyCatalog = new AssemblyCatalog(typeof (AssemblyPlugin).Assembly);
            var directoryCatalog =
                new DirectoryCatalog(                  Directory.GetCurrentDirectory());
            var typeCatalog = new TypeCatalog(new[] { typeof(ExportHost)});
            
            _catalog.Catalogs.Add(assemblyCatalog);
            _catalog.Catalogs.Add(directoryCatalog);
            _catalog.Catalogs.Add(typeCatalog);
            
            var container = new CompositionContainer(_catalog);

            var debugger = new MefDebugger(container);

            container.ComposeParts(this);     
       
            debugger.Close();

            foreach(var plugin in Plugins)
            {
                plugin.DoSomething();
            }

            Console.ReadLine();
        }
    }
}
