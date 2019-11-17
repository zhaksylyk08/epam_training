using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.OnlineShop
{
    class Comment
    {
        public int CommentID { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public string CommentText { get; set; }
    }
}
