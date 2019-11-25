using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.OnlineShop
{
    public class Order
    {
        public int OrderId { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
