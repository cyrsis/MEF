using System;
using System.ComponentModel.Composition;
using MyFirstMEF.Contracts;

namespace MyFirstMEF
{
    public class Logger : ILogger 
    {
        private static Logger _logger;

        private Logger()
        {
            
        }

        public static ILogger GetLogger()
        {
            return _logger ?? (_logger = new Logger());
        }

        public void Log(string data)
        {
            Console.WriteLine("Logger: {0}",data);
        }
    }
}