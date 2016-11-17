using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using DataTransformer;

namespace MyFirstMEF
{
    class Program
    {
        [Import]
        public IDataTransform Transformer { get; set; }

        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }                

        public void Run()
        {
            var catalog = new AggregateCatalog();
            var directoryCatalog =
                new DirectoryCatalog(
                    @"C:\Users\Jeremy Likness\Documents\Wintellect\Projects\Pearson\Code\MyFirstMEFSln\MyFirstMEF\bin\Debug\plugins");
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IDataTransform).Assembly));
            catalog.Catalogs.Add(directoryCatalog);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            while (true)
            {
                directoryCatalog.Refresh();
                Transformer.Transform();
                Console.ReadLine();
            }
        }
    }
}
