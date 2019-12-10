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
    public class AwardController : Controller
    {
        private WebAppContext _webAppContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AwardController(WebAppContext webAppContext, IHostingEnvironment hostingEnvironment)
        {
            _webAppContext = webAppContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var awards = _webAppContext.Awards.ToList();

            return View(awards);
        }

        [HttpGet]
        public IActionResult AddAward()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAward(Award award)
        {
            if (ModelState.IsValid)
            {
                var file = HttpContext.Request.Form.Files.FirstOrDefault();

                if (file != null)
                {
                    var path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "images", "awards", file.FileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.OpenReadStream().CopyTo(fileStream);
                        award.ImageUrl = file.FileName;
                    }
                }
                else
                {
                    ModelState.AddModelError("ImageUrl", "Image is very important");
                }
            }

            _webAppContext.Awards.Add(award);
            _webAppContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}