using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;

namespace UnderstandingParts
{
    class Program
    {
        [ImportMany]
        public string[] Text { get; set; }

        [Import("SpecialText")]
        public string SpecialText { get; set; }

        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }
        
        public void Run()
        {
            var catalog = new AggregateCatalog(new AssemblyCatalog(GetType().Assembly));
            var container = new CompositionContainer(catalog);
            var debugger = new MefDebugger(container); 
            container.ComposeParts(this);
            debugger.Close();
            foreach(var text in Text)
            {
                Console.WriteLine("Text: {0}", text);
            }
            Console.WriteLine("Special Text: {0}", SpecialText);
            Console.ReadLine();  
        }
    }
}
