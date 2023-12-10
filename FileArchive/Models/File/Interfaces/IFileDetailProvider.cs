using System;
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
        public FileDetail GetFileDetailByGuid(Guid guid);
        public Task DeleteFileDetail (int fileId);
        public Task UpdateFileDetail (FileDetail fileDetail);
    }
}