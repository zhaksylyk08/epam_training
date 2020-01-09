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
using DAL;

namespace WebApp2.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //private WebAppContext _webAppContext;
        //private IUserRepository _userRepository;
        private UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IHostingEnvironment _hostingEnvironment;

        public UserController(UnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment)
        {
            this.unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        [Route("/users")]
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();

            viewModel.Users = unitOfWork.UserRepository.GetAllUsers();
               
            return View(viewModel);

        }

        [Route("/users/{name}")]
        public IActionResult Index(string name)
        {
            var viewModel = new IndexViewModel();

            viewModel.Users = unitOfWork.UserRepository.GetUsersByName(name);

            return View(viewModel);

        }

        [Route("users/{firstLetter:length(1)}")]
        public IActionResult Index(char firstLetter)
        {
            var viewModel = new IndexViewModel();

            var result = unitOfWork.UserRepository.GetUsersByFirstLetterOfName(firstLetter);

            return View(viewModel);
        }

        /*[HttpGet("/create-user")]
        public IActionResult AddUser()
        {
            var user = new User();
            user.UserAwards = new List<UserAward>();
            PopulateAssignedAwardData(user);

            return PartialView("_AddUser");
        }*/

        public IActionResult AddUser()
        {
            return PartialView("_AddUser");
        }

        /* [HttpPost("/create-user")]
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
             return PartialView("_AddUser", user);
         }*/

        [HttpPost("/create-user")]
        public JsonResult AddUser(UserViewModel userViewModel)
        {
            var user = new User
            {
                Name = userViewModel.Name,
                Birthdate = userViewModel.Birthdate,
                Age = userViewModel.Age
            };

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

                //_webAppContext.Users.Add(user);
                //_webAppContext.SaveChanges();
                unitOfWork.UserRepository.AddUser(user);
                return Json(true);
            }

            return Json(false);
        }

        [Authorize(Roles = "admin")]
        public JsonResult Delete(int id)
        {
            var user = unitOfWork.UserRepository.GetUserById(id);

            if (user == null)
            {
                return Json(false);
            }
            //_webAppContext.Users.Remove(user);
            //_webAppContext.SaveChanges();
            unitOfWork.UserRepository.DeleteUser(user);

            return Json(true);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("/user/{id}/edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = unitOfWork.UserRepository.GetUserWithAwards(id);

            if (user == null)
            {
                return NotFound();
            }

            PopulateAssignedAwardData(user);
            return View(user);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("/user/{id}/edit")]
        public IActionResult Edit(int? id, string[] selectedAwards)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToUpdate = unitOfWork.UserRepository.GetUserWithAwards(id);

            UpdateUserAwards(selectedAwards, userToUpdate);
            //_webAppContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Route("user/{id}/details")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = unitOfWork.UserRepository.GetUserWithAwards(id);

            if (user == null) 
            {
                return NotFound();
            }

            return View(user);
        }

        /*[Route("user/{name}")]
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
        }*/

        private void PopulateAssignedAwardData(User user)
        {
            var allAwards = unitOfWork.AwardRepository.GetAllAwards();
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

            foreach (var award in unitOfWork.AwardRepository.GetAllAwards())
            {
                if (selectedAwardsHS.Contains(award.AwardId.ToString()))
                {
                    if (!userAwards.Contains(award.AwardId))
                    {
                        //userToUpdate.UserAwards.Add(new UserAward { UserId = userToUpdate.UserId, AwardId = award.AwardId });
                    }
                }
                else
                {
                    if (userAwards.Contains(award.AwardId))
                    {
                        //UserAward awardToRemove = userToUpdate.UserAwards
                                                    //.FirstOrDefault(a => a.AwardId == award.AwardId);
                        //_webAppContext.Remove(awardToRemove);
                    }
                }
            }
        }

    }
}