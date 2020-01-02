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
using Microsoft.AspNetCore.Authorization;

namespace WebApp2.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private WebAppContext _webAppContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UserController(WebAppContext webAppContext, IHostingEnvironment hostingEnvironment)
        {
            _webAppContext = webAppContext;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("/users")]
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

        [Route("/users/{name}")]
        public async Task<IActionResult> Index(string name)
        {
            var viewModel = new IndexViewModel();

            viewModel.Users = await _webAppContext.Users
                              .Include(user => user.UserAwards)
                                .ThenInclude(user => user.Award)
                              .Where(user => user.Name == name)
                              .OrderBy(user => user.Name)
                              .ToListAsync();

            return View(viewModel);

        }

        [Route("users/{firstLetter:length(1)}")]
        public async Task<IActionResult> Index(char firstLetter)
        {
            var viewModel = new IndexViewModel();

            viewModel.Users = await _webAppContext.Users
                              .Include(user => user.UserAwards)
                                .ThenInclude(user => user.Award)
                              .Where(user => user.Name.Substring(0,1) == firstLetter.ToString())
                              .OrderBy(user => user.Name)
                              .ToListAsync();

            return View(viewModel);
        }

        [HttpGet("/create-user")]
        public IActionResult AddUser()
        {
            var user = new User();
            user.UserAwards = new List<UserAward>();
            PopulateAssignedAwardData(user);

            return View();
        }

        [HttpPost("/create-user")]
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

        [HttpGet("user/{id}/delete")]
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

        [HttpPost("user/{id}/delete")]
        public IActionResult Delete(int id)
        {
            var user = _webAppContext.Users.Find(id);

            _webAppContext.Users.Remove(user);
            _webAppContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("/user/{id}/edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _webAppContext.Users
                        .Include(user => user.UserAwards)
                            .ThenInclude(user => user.Award)
                        .FirstOrDefault(user => user.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            PopulateAssignedAwardData(user);
            return View(user);
        }

        [HttpPost("/user/{id}/edit")]
        public IActionResult Edit(int? id, string[] selectedAwards)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToUpdate = _webAppContext.Users
                                .Include(user => user.UserAwards)
                                    .ThenInclude(user => user.Award)
                                .FirstOrDefault(user => user.UserId == id);

            UpdateUserAwards(selectedAwards, userToUpdate);
            _webAppContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Route("user/{id}/details")]
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

        [Route("user/{name}")]
        public IActionResult GetUserByName(string name)
        {
            var user = _webAppContext.Users
                        .Where(user => user.Name == name)
                        .Include(user => user.UserAwards)
                          .ThenInclude(user => user.Award)
                        .AsNoTracking()
                        .OrderBy(user => user.Birthdate)
                        .FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

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

        private void UpdateUserAwards(string[] selectedAwards, User userToUpdate)
        {
            if (selectedAwards == null) 
            {
                userToUpdate.UserAwards = new List<UserAward>();
                return;
            }

            var selectedAwardsHS = new HashSet<string>(selectedAwards);
            var userAwards = new HashSet<int>
                (userToUpdate.UserAwards.Select(user => user.AwardId));

            foreach (var award in _webAppContext.Awards)
            {
                if (selectedAwardsHS.Contains(award.AwardId.ToString()))
                {
                    if (!userAwards.Contains(award.AwardId))
                    {
                        userToUpdate.UserAwards.Add(new UserAward { UserId = userToUpdate.UserId, AwardId = award.AwardId });
                    }
                }
                else
                {
                    if (userAwards.Contains(award.AwardId))
                    {
                        UserAward awardToRemove = userToUpdate.UserAwards
                                                    .FirstOrDefault(a => a.AwardId == award.AwardId);
                        _webAppContext.Remove(awardToRemove);
                    }
                }
            }
        }

    }
}