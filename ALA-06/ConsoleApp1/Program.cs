using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.OnlineShop;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new OnlineShopContext())
            {
                var customer = new Customer { FirstName = "Sakura", LastName = "Atsushi" };
                db.Customers.Add(customer);
                db.SaveChanges();

                var query = from c in db.Customers
                            orderby c.FirstName
                            select c;

                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstName);
                }

                Console.ReadKey();
            }
        }
    }
}
