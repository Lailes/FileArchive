using System.Collections.Generic;
using System.Threading.Tasks;
using FileArchive.Models.File.FileModels;

namespace FileArchive.Models.File.Interfaces
{
    public interface IFileDetailProvider
    {
        public IEnumerable<FileDetail> GetFileDetailForUser (string user);
        public Task SaveFileDetailAsync (FileDetail fileDetail);
        public FileDetail GetFileDetailById (int fileId);
        public Task DeleteFileDetail (int fileId);
    }
}