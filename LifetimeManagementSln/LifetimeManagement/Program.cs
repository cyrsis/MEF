using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;

namespace LifetimeManagement
{
    class Program
    {
        [Import(RequiredCreationPolicy = CreationPolicy.Any)]
        public IKeyProvider Key1 { get; set; }

        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]        
        public IKeyProvider Key2 { get; set; }

        [Import]
        public IKeyProvider Key3 { get; set; }
        
        static void Main(string[] args)
        {
            var p = new Program();
            var catalog = new AssemblyCatalog(typeof (Program).Assembly);
            var container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(p);
            Console.WriteLine(p.Key1.Key);
            Console.WriteLine(p.Key2.Key);
            Console.WriteLine(p.Key2.Key);
            Console.WriteLine(p.Key3.Key);
            Console.ReadLine();
        }
    }
}
