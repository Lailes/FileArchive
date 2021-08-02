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
        private readonly IUserLevelProvider _userLevelProvider;
        private readonly ISpaceProvider _spaceProvider;

        public ProfileController (IFileManager fileManager, UserManager<FileArchiveUser> userManager, IUserLevelProvider userLevelProvider, ISpaceProvider spaceProvider)
        {
            _fileManager = fileManager;
            _userManager = userManager;
            _userLevelProvider = userLevelProvider;
            _spaceProvider = spaceProvider;
        }

        [HttpGet]
        [Route("/Profile")]
        public async Task<IActionResult> OverView ()
        {
            if (User is not {Identity: { }})
                return View("ViewProfile", null);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userDetails = _fileManager.GetFileDetailsForUser(User.Identity.Name).ToList();
            var status = _userLevelProvider.GetStatus(user.Email);
            
            return View("ViewProfile", new ProfileInfo {
                UserName = user.Name,
                EMail = user.Email,
                FileCount = userDetails.Count,
                TotalBytes = _spaceProvider.GetSpaceForStatus(status),
                UserLevel = _spaceProvider.GetStringDescription(status),
                UsedBytes = await _fileManager.GetUsedBytesAsync(user.Email)
            });
        }
    }
}