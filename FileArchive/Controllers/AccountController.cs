using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        
        [HttpGet]
        public async Task<ActionResult> ViewProfile()
        {
            return View("Files", new []{"1", "2", "3"});
        }
    }
} 