using FileArchive.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        private readonly IFileProvider _fileProvider;

        public PanelController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public ViewResult Files()
        {
            return View("Files", User?.Identity?.Name);
        }
        
    }
} 