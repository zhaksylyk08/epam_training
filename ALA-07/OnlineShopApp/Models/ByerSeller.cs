using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Model
{
    public class BuyerSeller : BaseModel
    {
        public virtual Seller Seller { get; set; }
        public virtual  Customer Customer { get; set; }
    }
}
