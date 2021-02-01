using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerFactory.CustomerManager cm = new LoggerFactory.CustomerManager();
            cm.Save();

            Console.ReadLine();
        }
    }

    public class LoggerFactory : LoggerFactory.ILoggerFactory
    {


        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new EdLogger();
        }

        public interface ILogger
        {
            void Log();
        }

        public interface ILoggerFactory
        {

        }

        public class EdLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged With EdLogger");
            }
        }

        public class CustomerManager
        {
            public void Save()
            {
                Console.WriteLine("Saved");
                ILogger logger = new LoggerFactory().CreateLogger();
                logger.Log();
            }
        }
    }
}
