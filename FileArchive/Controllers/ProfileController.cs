using System.Linq;
using System.Threading.Tasks;
using FileArchive.Models;
using FileArchive.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{    
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly UserManager<FileArchiveUser> _userManager;

        public ProfileController(IFileProvider fileProvider, UserManager<FileArchiveUser> userManager)
        {
            _fileProvider = fileProvider;
            _userManager = userManager;
        }

        [HttpGet] 
        [Route("/Profile")]
        public async Task<IActionResult> OverView()
        {
            if (User is not {Identity: { }}) return View("ViewProfile", null);
            
            var userDetails = _fileProvider.GetFileDetailsForName(User?.Identity?.Name).ToList();
            var name = (await _userManager.FindByNameAsync(User.Identity.Name))?.Name;
            
            return View("ViewProfile", new ProfileInfo {
                UserName = name,
                BytesCount = userDetails.Sum(detail => (long) detail.BytesCount),
                FileCount = userDetails.Count
            });
        }
    }
}