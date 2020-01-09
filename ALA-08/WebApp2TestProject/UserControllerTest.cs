using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WebApp2.Controllers;
using DAL.EFData;
using Moq;
using Microsoft.AspNetCore.Hosting;
using System.Collections;
using DAL;
using DAL.Models;
using WebApp2.ViewModels;
using System.Collections.Generic;
using System;
using System.Linq;

namespace WebApp2TestProject
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            //var mockDbContext = new Mock<IUserRepository>();
            var mockHostingEnv = new Mock<IHostingEnvironment>();
            var mockUnitOfWork = new Mock<UnitOfWork>();
            mockUnitOfWork.Setup(uof => uof.UserRepository.GetAllUsers())
                .Returns(GetTestUsers());

            var controller = new UserController(mockUnitOfWork.Object, mockHostingEnv.Object);
            var result = controller.Index() as ViewResult;


            Assert.AreEqual("Index", result.ViewName);
            var model = result.ViewData;
            Assert.AreEqual(2, model.Count());
        }

        private List<User> GetTestUsers()
        {
            var users = new List<User>();
            users.Add(new User()
            {
                UserId = 1,
                Name = "Lilly",
                Birthdate = new DateTime(2015, 7, 1),
                Age = 15
            });

            users.Add(new User()
            {
                UserId = 2,
                Name = "John",
                Birthdate = new DateTime(2001, 4, 5),
                Age = 19
            });

            return users;
        }
    }
}
