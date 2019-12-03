using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Models;

namespace WebApp2.EFData
{
    public class WebAppContext: DbContext
    {
        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Award> Awards { get; set; }
    }
}
