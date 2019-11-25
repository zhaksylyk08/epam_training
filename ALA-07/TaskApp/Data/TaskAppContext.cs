using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.Models
{
    public class TaskAppContext : DbContext
    {
        public TaskAppContext (DbContextOptions<TaskAppContext> options)
            : base(options)
        {
        }

        public DbSet<TaskApp.Models.User> User { get; set; }

        public DbSet<TaskApp.Models.Prize> Prize { get; set; }
    }
}
