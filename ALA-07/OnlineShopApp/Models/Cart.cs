using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.OnlineShop
{
    public class Cart
    {
        public int CartId { get; set; }

        public Customer Customer { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
