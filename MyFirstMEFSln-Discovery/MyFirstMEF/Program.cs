using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using MyFirstMEF.Contracts;

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
                new DirectoryCatalog(Directory.GetCurrentDirectory());
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(directoryCatalog);
            var container = new CompositionContainer(catalog);
            container.ComposeExportedValue(Logger.GetLogger());
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
