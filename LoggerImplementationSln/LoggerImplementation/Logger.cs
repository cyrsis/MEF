using System;
using System.ComponentModel.Composition;
using PluginManager.Contracts;

namespace LoggerImplementation
{
    [Export(typeof(ILogger))]
    public class Logger : ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }  
}
