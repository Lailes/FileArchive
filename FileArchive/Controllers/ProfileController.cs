using System.Linq;
using System.Threading.Tasks;
using FileArchive.Models.Account;
using FileArchive.Models.File.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IFileManager _fileManager;
        private readonly UserManager<FileArchiveUser> _userManager;

        public ProfileController (IFileManager fileManager, UserManager<FileArchiveUser> userManager)
        {
            _fileManager = fileManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("/Profile")]
        public async Task<IActionResult> OverView ()
        {
            if (User is not {Identity: { }})
                return View("ViewProfile", null);

            var userDetails = _fileManager.GetFileDetailsForUser(User.Identity.Name).ToList();
            var userName = (await _userManager.FindByNameAsync(User.Identity.Name))?.Name;

            return View("ViewProfile", new ProfileInfo {
                UserName = userName,
                BytesCount = userDetails.Sum(detail => detail.BytesCount),
                FileCount = userDetails.Count
            });
        }
    }
}