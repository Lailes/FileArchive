using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();
    }
}