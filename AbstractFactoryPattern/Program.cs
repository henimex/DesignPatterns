using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Program
    {


        static void Main(string[] args)
        {
            ProductManger productManger = new ProductManger(new FactoryOne());
            Console.WriteLine("Factory One---------- Tamamen Oturdu Super İşe Yarar");
            productManger.GetAll();
            Console.WriteLine("Factory Two---------- Her seferinde ayarlamak yerine mevcut kod degistirilmeden arkadan yapılan tek bir ayar ile sistemin işleyişi değişebilir.");
            ProductManger productManger2 = new ProductManger(new FactoryTwo());
            productManger2.GetAll();

            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string msg);
    }

    public class LogForNet : Logging
    {
        public override void Log(string msg)
        {
            Console.WriteLine("Logged with Log4Net {0}", msg);
        }
    }

    public class NLogger : Logging
    {
        public override void Log(string msg)
        {
            Console.WriteLine("Logged with NLogger {0}", msg);
        }
    }

    public abstract class Cashing
    {
        public abstract void Cash(string data);
    }

    public class RedisCache : Cashing
    {
        public override void Cash(string data)
        {
            Console.WriteLine("Cashed With Redis{0}", data);
        }
    }

    public class MemCache : Cashing
    {
        public override void Cash(string data)
        {
            Console.WriteLine("Cashed With MemCache {0}", data);
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Cashing CreateCasher();
    }

    //you can make more different type an optioned factories
    public class FactoryOne : CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new LogForNet();
        }

        public override Cashing CreateCasher()
        {
            return new MemCache();
        }
    }

    public class ProductManger
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Cashing _cashing;

        public ProductManger(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _cashing = _crossCuttingConcernsFactory.CreateCasher();
            _logging = _crossCuttingConcernsFactory.CreateLogger();
        }

        public void GetAll()
        {
            Console.WriteLine("Products listed");
            _logging.Log("Deneme Base");
            _cashing.Cash("Deneme Base");
        }
    }

    public class FactoryTwo : CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new NLogger();
        }

        public override Cashing CreateCasher()
        {
            return new RedisCache();
        }
    }
}
