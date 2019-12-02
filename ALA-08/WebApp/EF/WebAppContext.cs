using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.EF
{
    public class WebAppContext: DbContext
    {
        public WebAppContext(DbContextOptions<WebAppContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Award> Awards { get; set; }
    }
}
