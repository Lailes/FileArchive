using System.Threading.Tasks;
using FileArchive.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<FileArchiveUser> _userManager;
        private readonly SignInManager<FileArchiveUser> _signInManager;

        public AuthController(UserManager<FileArchiveUser> userManager, SignInManager<FileArchiveUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet] 
        public ViewResult LogIn() => View(new LogInData());

        [HttpGet] 
        public ViewResult SighUp() => View(new SignUpData());

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInData data)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Wrong input data");
                return View(data);
            }

            var user = await _userManager.FindByEmailAsync(data.EMail);
            
            if (user == null)
            {
                await _signInManager.SignOutAsync();
                ModelState.AddModelError("", "User with e-mail is not exists");
                return View(data);
            }

            var result =  await _signInManager.PasswordSignInAsync(user, data.Password, false, false);
            
            if (result.Succeeded)
                return Redirect("/Profile");
            
            ModelState.AddModelError("", "Wrong login or password");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SighUp(SignUpData signUpData)
        {
            var user = await _userManager.FindByEmailAsync(signUpData.EMail);
            if (user != null)
            {
                ModelState.AddModelError("", "User with this name is already exists");
                return View(signUpData);
            }

            var result = await _userManager.CreateAsync(
                new FileArchiveUser {
                    UserName = signUpData.EMail,
                    Email = signUpData.EMail,
                    Name = signUpData.Name
                }, 
                signUpData.Password);
            
            if (result.Succeeded)
                return Redirect("/Profile");
            
            foreach (var identityError in result.Errors)
                ModelState.AddModelError("", identityError.Description);
            
            return View(signUpData);
        }

        public async Task<IActionResult> SighOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}