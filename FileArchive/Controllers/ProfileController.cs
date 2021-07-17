using System.Linq;
using FileArchive.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{    
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IFileProvider _fileProvider;

        public ProfileController(IFileProvider fileProvider) => _fileProvider = fileProvider;

        [HttpGet] [Route("/Profile")]
        public IActionResult OverView()
        {
            if (User is not {Identity: { }}) return View("ViewProfile", null);
            
            var userDetails = _fileProvider.FileDetails.Where(detail => detail.Owner == User.Identity.Name).ToList();
            
            return View("ViewProfile", new ProfileInfo {
                UserName = User.Identity.Name,
                BytesCount = userDetails.Sum(detail => (long) detail.BytesCount),
                FileCount = userDetails.Count
            });
        }
    }
}