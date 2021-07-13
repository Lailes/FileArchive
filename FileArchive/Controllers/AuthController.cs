using FileArchive.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{
    public class AuthController : Controller
    {

        [HttpGet]
        public ViewResult LogIn() => View(new AuthData());

        [HttpGet]
        public ViewResult SighUp() => View(new AuthData());

        [HttpPost]
        public ViewResult LogIn(AuthData data)
        {
            
            return View(data);
        }
        
    }
}