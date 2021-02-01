using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bu olay ninjectin acılımı işleyişi


            var customerManager = CustomerManager.CreateAsSingleton();


            Console.WriteLine(customerManager.DoSomething());
            customerManager.Add();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        private static object _lockObject = new object();

        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            //return _customerManager ?? (_customerManager = new CustomerManager());
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }

        public int DoSomething()
        {
            return 3;
        }

        public void Add()
        {
            Console.WriteLine("Added");
        }
    }
}
