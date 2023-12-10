using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FileArchive.Infrastructure;
using FileArchive.Infrastructure.Extensions;
using FileArchive.Models;
using FileArchive.Models.Account;
using FileArchive.Models.File.FileModels;
using FileArchive.Models.File.Interfaces;

// ReSharper disable PossibleNullReferenceException

namespace FileArchive.Controllers
{
    [Authorize]
    [Route("Files")]
    public class FileController : Controller
    {
        private readonly IFileManager _fileManager;   
        private readonly ISpaceProvider _spaceProvider;
        private readonly IUserLevelProvider _userLevelProvider;

        public FileController (IFileManager fileManager, ISpaceProvider spaceProvider, IUserLevelProvider userLevelProvider)
        {
            _fileManager = fileManager;
            _spaceProvider = spaceProvider;
            _userLevelProvider = userLevelProvider;
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

            var usedBytes = await _fileManager.GetUsedBytesAsync(User.Identity.Name);
            var totalBytes = _spaceProvider.GetSpaceForStatus(_userLevelProvider.GetStatus(User.Identity.Name));
            
            if (totalBytes < usedBytes + file.Length)
                return View("Error", new Exception("No enouth space"));
            
            await _fileManager.SaveFile(new ArchiveFile {
                Name = file.FileName,
                OwnerEmail = User.Identity.Name,
                Stream = file.OpenReadStream()
            });

            return Redirect("/Files/List");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Shared/{fileId:guid}")]
        public async Task<IActionResult> DownloadAnonymus (Guid fileId)
        {
            await using var file = _fileManager.GetArchiveFileByGuid(fileId);
                
            if (file is null)
                return NotFound();
            
            return File(await file.Stream.ReadArrayAsync(), "application/xxx", file.Details.FileName);
        }

        [HttpGet]
        [Route("[action]/{page:int?}")]
        public IActionResult List (int page = 1)
        {
            var detailsForUser = _fileManager
                                .GetFileDetailsForUser(User.Identity.Name)
                                .OrderByDescending(detail => detail.UploadDateTime)
                                .ToList();

            var info = new PaginationInfo {
                PageNumber = page,
                ItemsPerPage = Constants.PageSize,
                TotalItems = detailsForUser.Count,
                FileDetails = detailsForUser
                                       .Skip((page - 1) * Constants.PageSize)
                                       .Take(Constants.PageSize)
            };

            if (page != 1 && !info.FileDetails.Any())
                return RedirectToAction("List", page - 1);
            
            return View(info);
        }

        [HttpGet]
        [Route("[action]/{fileId:int}")]
        public IActionResult Detail (int fileId, int backPage = 1)
        {
            var file = _fileManager
                      .GetFileDetailsForUser(User.Identity.Name)
                      .FirstOrDefault(detail => detail.Id == fileId);
            

            return file == null 
                ? View("Error", new FileNotFoundException("File not found")) 
                : View(new FileDetailModel { FileDetail = file, BackPage = backPage});
        }

        [HttpGet]
        [Route("[action]/{fileId:int}")]
        public async Task<IActionResult> Delete (int fileId, int backPage)
        {
            if (!_fileManager.VerifyOwner(fileId, User.Identity.Name))
                return NotFound();
            
            await _fileManager.DeleteArchiveFileByIdAsync(fileId);
            
            return RedirectToAction("List", backPage);
        }

        [HttpGet]
        [Route("[action]/{fileId:int}")]
        public async Task<IActionResult> ChangeSharedAccess (int fileId, bool access, int page = 1)
        {
            if (!_fileManager.VerifyOwner(fileId, User.Identity.Name))
                return NotFound();
                
            await _fileManager.UpdateArchiveFileAsync(new FileUpdateInfo {Id = fileId, NewAccess = access ? Guid.NewGuid() : null });
            
            return RedirectToAction("Detail", new []{fileId, page});
        }
    }

    
}