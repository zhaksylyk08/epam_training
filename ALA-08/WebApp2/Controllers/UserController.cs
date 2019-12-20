using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using DAL.EFData;
using DAL.Models;
using WebApp2.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();

            viewModel.Users = await _webAppContext.Users
                              .Include(user => user.UserAwards)
                                .ThenInclude(user => user.Award)
                              .OrderBy(user => user.Name)
                              .ToListAsync();
                                                                
            return View(viewModel);

        }

        [HttpGet]
        public IActionResult AddUser()
        {
            //PopulateAwardsDropDownList();
            var user = new User();
            user.UserAwards = new List<UserAward>();
            PopulateAssignedAwardData(user);

            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserViewModel userViewModel, string[] selectedAwards)
        {
            var user = new User
            {
                Name = userViewModel.Name,
                Birthdate = userViewModel.Birthdate,
                Age = userViewModel.Age
            };

            if (selectedAwards != null)
            {
                user.UserAwards = new List<UserAward>();
                foreach (var award in selectedAwards)
                {
                    var awardToAdd = new UserAward { UserId = user.UserId, AwardId = int.Parse(award) };
                    user.UserAwards.Add(awardToAdd);
                }
            }
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

                _webAppContext.Users.Add(user);
                _webAppContext.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateAssignedAwardData(user);
            return View(user);
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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _webAppContext.Users
                .Include(user => user.UserAwards)
                    .ThenInclude(user => user.Award)
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.UserId == id);

            if (user == null) 
            {
                return NotFound();
            }

            return View(user);
        }

        /*private void PopulateAwardsDropDownList(object selectedAward = null)
        {
            var awardsQuery = from award in _webAppContext.Awards
                              orderby award.Title
                              select award;
            ViewBag.AwardId = new SelectList(awardsQuery.AsNoTracking(), "AwardId", "Title", selectedAward);
        }*/

        private void PopulateAssignedAwardData(User user)
        {
            var allAwards = _webAppContext.Awards;
            var userAwards = new HashSet<int>(user.UserAwards.Select(u => u.AwardId));
            var viewModel = new List<AssignedAwardData>();

            foreach (var award in allAwards)
            {
                viewModel.Add(new AssignedAwardData
                {
                    AwardId = award.AwardId,
                    Title = award.Title,
                    Assigned = userAwards.Contains(award.AwardId)
                });
            }

            ViewData["Awards"] = viewModel;
        }
    }
}