using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Text;

namespace Container
{
    class Program
    {
        [ImportMany(AllowRecomposition = true)]
        public string[] Text { get; set; }

        [Import("SpecialText", AllowDefault=true, AllowRecomposition = true)]
        public string SpecialText { get; set; }
        
        static void Main(string[] args)
        {
            var p = new Program();
            var directoryCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory());
            var catalog = new AggregateCatalog(new ComposablePartCatalog[]
                                                   {
                                                       directoryCatalog,
                                                       new AssemblyCatalog(typeof (Program).Assembly)
                                                   });
            var container = new CompositionContainer(catalog);
            var debugger = new MefDebugger(container);
            container.ComposeParts(p);
            p.Run();
            directoryCatalog.Refresh();
            p.Run();
            debugger.Close();
        }

        public void Run()
        {
            foreach(var text in Text)
            {
                Console.WriteLine(text);
            }
            Console.WriteLine(SpecialText ?? string.Empty);
            Console.ReadLine();
        }
    }
}
