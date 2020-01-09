using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DAL.EFData;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class UnitOfWork
    {
        private WebAppContext webAppContext;
        private IUserRepository userRepository;
        private IAwardRepository awardRepository;

        public UnitOfWork()
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=WebApp2;Integrated Security=True;";
            var optionsBuilder = new DbContextOptionsBuilder<WebAppContext>();
            optionsBuilder.UseSqlServer(connectionString);
            webAppContext = new WebAppContext(optionsBuilder.Options);
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(webAppContext);
                }

                return userRepository;
            }
        }

        public IAwardRepository AwardRepository
        {
            get
            {
                if (this.awardRepository == null)
                {
                    this.awardRepository = new AwardRepository(webAppContext);
                }

                return awardRepository;
            }
        }
    }
}
