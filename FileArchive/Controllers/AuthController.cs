using System.Threading.Tasks;
using FileArchive.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ViewResult LogIn() => View(new AuthData());

        [HttpGet]
        public ViewResult SighUp() => View(new AuthData());

        [HttpPost]
        public async Task<ViewResult> LogIn(AuthData data)
        {
            return View(data);
        }
        
    }
}