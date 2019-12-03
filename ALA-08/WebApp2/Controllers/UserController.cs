using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp2.EFData;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class UserController : Controller
    {
        private WebAppContext _webAppContext;

        public UserController(WebAppContext webAppContext)
        {
            _webAppContext = webAppContext;
        }
        public IActionResult Index()
        {
            var users = _webAppContext.Users.ToList();
            return View(users);
        }

        /*public IActionResult AddUser()
        {
            var user = new User()
            {
                Name = "John",
                Birthdate = new DateTime(1996, 5, 12),
                Age = 23
            };

            _webAppContext.Users.Add(user);
            _webAppContext.SaveChanges();

            return RedirectToAction("Index");
        }*/

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _webAppContext.Add(user);
                _webAppContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _webAppContext.Users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _webAppContext.Users.Find(id);
            _webAppContext.Users.Remove(user);
            _webAppContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}