using System.Linq;
using FileArchive.Infrastructure;
using FileArchive.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PanelController : Controller
    {
        private readonly IFileProvider _fileProvider;

        public PanelController(IFileProvider fileProvider) => _fileProvider = fileProvider;

        [Route("Files/{page:int?}")]
        public ViewResult Files(int page = 1)
        {
            if (User is not {Identity: { }})
                return View("Files", null);
            
            var detailsForUser = 
                _fileProvider.GetFileDetailsForName(User?.Identity?.Name).ToList();
            
            var info = new PaginationInfo {
                PageNumber = page,
                ItemsPerPage = Constants.PageSize,
                TotalItems = detailsForUser.Count,
                FileDetailsEnumerable = detailsForUser
                    .Skip((page - 1) * Constants.PageSize)
                    .Take(Constants.PageSize)
            };
            
            return View(info);
        }
            
    }
} 