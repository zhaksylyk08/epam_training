using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
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

        [HttpGet]
        public IActionResult Login(string returnUrl = null) 
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel) 
        {
            if (ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password,
                    viewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(viewModel.ReturnUrl) && Url.IsLocalUrl(viewModel.ReturnUrl))
                    {
                        return Redirect(viewModel.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else 
                {
                    ModelState.AddModelError("", "Invalid login or(and) password");
                }
            }

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}