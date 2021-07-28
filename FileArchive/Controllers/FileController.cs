using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileArchive.Infrastructure;
using FileArchive.Models;
using FileArchive.Models.File.FileModels;
using FileArchive.Models.File.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// ReSharper disable PossibleNullReferenceException

namespace FileArchive.Controllers
{
    [Authorize]
    [Route("Files")]
    public class FileController : Controller
    {
        private readonly IFileManager _fileManager;

        public FileController (IFileManager fileManager)
        {
            _fileManager = fileManager;
        }


        [HttpGet]
        [Route("Download/{fileId:int}")]
        public async Task<IActionResult> DownloadFile (int fileId)
        {
            await using var file = _fileManager.GetArchiveFileById(fileId);
            
            if (file != null && file.Details.OwnerEmail == User.Identity.Name)
                return File(await file.Stream.ReadArrayAsync(), "application/xxx", file.Name);
            
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile (IFormFile file)
        {
            if (file == null)
                return Redirect("/Files/List");

            await _fileManager.SaveFile(new ArchiveFile {
                Name = file.FileName,
                OwnerEmail = User.Identity.Name,
                Stream = file.OpenReadStream()
            });
 
            return Redirect("/Files/List");
        }

        [HttpGet]
        [AllowAnonymous] // TODO: Proof speed of stream and bytes coping
        [Route("Shared/{fileId:int}")]
        public async Task<IActionResult> DownloadAnonymus (int fileId)
        {
            await using var file = _fileManager.GetArchiveFileById(fileId);
                
            if (!file.Details.AllowAnonymus)
                return NotFound();
            
            return File(await file.Stream.ReadArrayAsync(), "application/xxx", file.Details.FileName);
        }

        [HttpGet]
        [Route("[action]/{page:int?}")]
        public ViewResult List (int page = 1)
        {
            var detailsForUser = _fileManager
                                .GetFileDetailsForUser(User.Identity.Name)
                                .OrderByDescending(detail => detail.UploadDateTime)
                                .ToList();

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

        [HttpGet]
        [Route("[action]/{fileId:int}")]
        public ViewResult Detail (int fileId, int backPage = 1)
        {
            var file = _fileManager
                      .GetFileDetailsForUser(User.Identity.Name)
                      .FirstOrDefault(detail => detail.Id == fileId);
            
            return file == null 
                ? View("Error", new FileNotFoundException("File not found")) 
                : View(new FileDetailModel { FileDetail = file, BackPage = backPage});
        }
    }
}