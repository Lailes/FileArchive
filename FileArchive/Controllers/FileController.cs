using System;
using System.Linq;
using System.Threading.Tasks;
using FileArchive.Infrastructure;
using FileArchive.Models;
using FileArchive.Models.File;
using FileArchive.Models.File.FileModels;
using FileArchive.Models.File.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<FileResult> DownloadFile (int fileId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile (IFormFile file)
        {
            if (file == null)
                return Redirect("/Files/List");

            try
            {
                await _fileManager.SaveFile(new ArchiveFile {
                    Name = file.FileName,
                    OwnerUserName = User.Identity.Name,
                    Stream = file.OpenReadStream()
                });

                return Redirect("/Files/List");
            }
            catch (Exception e)
            {
                return View("Error", e.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous] // TODO: Proof speed of stream and bytes coping
        [Route("[action]/{fileId:int}")]
        public IActionResult DownloadAnonymus (int fileId)
        {
            try
            {
                var file = _fileManager.GetArchiveFileById(fileId);
                
                if (file.Details.AllowAnonymus)
                    return File(file.Stream, "application/xxx", file.Details.FileName);
                
                return NotFound();
            }
            catch (Exception e)
            {
                return View("Error", e.Message);
            }
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
        public ViewResult Detail (int fileId)
        {
            var file = _fileManager
                      .GetFileDetailsForUser(User.Identity.Name)
                      .FirstOrDefault(detail => detail.Id == fileId);

            return file == null ? View("Error", "No such file") : View(file);
        }
    }
}