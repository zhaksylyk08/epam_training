using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.OnlineShop
{
    class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public Order Order { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
