using System.Collections.Generic;
using System.Threading.Tasks;
using FileArchive.Models.File.FileModels;

namespace FileArchive.Models.File.Interfaces
{
    public interface IFileManager
    {
        public Task SaveFile (ArchiveFile archiveFile);
        public IEnumerable<FileDetail> GetFileDetailsForUser (string userName);
        public ArchiveFile GetArchiveFileById (int fileId);
        public Task DeleteArchiveFileByIdAsync (int fileId);
        public Task UpdateArchiveFile (FileUpdateInfo info);
        public bool VerifyOwner (int fileId, string userName);
        Task<long> GetUsedBytesAsync (string userEmail);
    }
}