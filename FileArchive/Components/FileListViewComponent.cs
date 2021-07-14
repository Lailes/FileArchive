using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileArchive.Models;


namespace FileArchive.Components
{
    public class FileListViewComponent: ViewComponent
    {
        private readonly IFileProvider _fileProvider;

        public FileListViewComponent(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _fileProvider.GetFilesForUserAsync(User?.Identity?.Name));
        }
    }
}