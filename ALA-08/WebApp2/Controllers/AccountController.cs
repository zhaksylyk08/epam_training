using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp2.ViewModels;

namespace WebApp2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public AccountController(UserManager<Account> userManager, SignInManager<Account> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterViewModel viewModel) 
        {
            if (ModelState.IsValid)
            {
                Account account = new Account
                {
                    Email = viewModel.Email,
                    UserName = viewModel.Email
                };

                var result = await _userManager.CreateAsync(account, viewModel.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(account, false);
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(viewModel);
        }
    }
}