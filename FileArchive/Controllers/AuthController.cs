using System;
using System.Threading.Tasks;
using FileArchive.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public ViewResult LogIn() => View(new AuthData());

        [HttpGet]
        public ViewResult SighUp() => View(new AuthData());

        [HttpPost]
        public async Task<IActionResult> LogIn(AuthData data)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Wrong input data");
                return View(data);
            }

            var user = await _userManager.FindByNameAsync(data.LogIn);
            
            if (user == null)
            {
                await _signInManager.SignOutAsync();
                ModelState.AddModelError("", "User with this login is not exists");
                return View(data);
            }

            var result =  (await _signInManager.PasswordSignInAsync(data.LogIn, data.Password, false, false)).Succeeded;

            if (result)
            {
                return Redirect("/Profile");
            }
            
            ModelState.AddModelError("", "Wrong login or password");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SighUp(AuthData authData)
        {
            var user = await _userManager.FindByNameAsync(authData.LogIn);
            if (user != null)
            {
                ModelState.AddModelError("", "User with this name is already exists");
                return View(authData);
            }

            var result = await _userManager.CreateAsync(new IdentityUser(authData.LogIn), authData.Password);
            
            if (result.Succeeded)
                return Redirect("/Profile");
            
            foreach (var identityError in result.Errors)
                ModelState.AddModelError("", identityError.Description);
            
            return View(authData);
        }

        public async Task<IActionResult> SighOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}