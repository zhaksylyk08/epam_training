using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.EFData
{
    public class WebAppContext: DbContext
    {
        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<UserAward> UserAwards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAward>()
                                .HasKey(ua => new { ua.UserId, ua.AwardId });
        }
    }
}
