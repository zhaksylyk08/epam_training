using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.OnlineShop
{
    class Order
    {
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public Seller Seller { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime RequiredDate { get; set; }


        public ICollection<Product> Products { get; set; }

    }
}
