using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer {Name = "İsim", Surname = "Soyisim", City = "Şehir", Id = 1};
            Customer customer2 = (Customer) customer1.Clone();
            customer2.Name = "Deneme";

            Console.WriteLine(customer1.Name);
            Console.WriteLine(customer2.Name);
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
