using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileArchive.Models.File.FileModels;
using FileArchive.Models.File.Interfaces;

namespace FileArchive.Models.File.Implementations
{
    public class FileDetailProvider : IFileDetailProvider
    {
        private readonly ApplicationContext _applicationContext;

        public FileDetailProvider (ApplicationContext applicationContext) =>
            _applicationContext = applicationContext;
        

        public IEnumerable<FileDetail> GetFileDetailForUser (string user) =>
             _applicationContext.FileDetails.Where(detail => detail.OwnerEmail == user);
        

        public async Task SaveFileDetailAsync (FileDetail fileDetail)
        {
            await _applicationContext.FileDetails.AddAsync(fileDetail);
            await _applicationContext.SaveChangesAsync();
        }

        public FileDetail GetFileDetailById (int fileId) =>
            _applicationContext.FileDetails.FirstOrDefault(detail => detail.Id == fileId);
    }
}
