using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using DAL.EFData;
using DAL.Models;

namespace WebApp2.Controllers
{
    public class UserController : Controller
    {
        private WebAppContext _webAppContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UserController(WebAppContext webAppContext, IHostingEnvironment hostingEnvironment)
        {
            _webAppContext = webAppContext;
            _hostingEnvironment = hostingEnvironment;
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
            /*if (ModelState.IsValid)
            {
                _webAppContext.Add(user);
                _webAppContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();*/

            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files.FirstOrDefault();

                if (file != null)
                {
                    var path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "images", "users", file.FileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.OpenReadStream().CopyTo(fileStream);
                        user.ImageUrl = file.FileName;
                    }
                }
                else 
                {
                    //ModelState.AddModelError("ImageUrl", "Image is very important");
                    user.ImageUrl = "default_img.jpg";
                }
            }

            _webAppContext.Users.Add(user);
            _webAppContext.SaveChanges();

            return RedirectToAction("Index");
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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _webAppContext.Users
                        .Where(u => u.UserId == id)
                        .FirstOrDefault<User>();

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(int id, User user2)
        {
            var user = _webAppContext.Users.Find(id);

            user.Name = user2.Name;
            user.Birthdate = user2.Birthdate;
            user.Age = user2.Age;

            _webAppContext.Users.Update(user);
            _webAppContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}