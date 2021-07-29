using System.IO;
using System.Threading.Tasks;
using FileArchive.Models.File.FileModels;

namespace FileArchive.Models.File.Interfaces
{
    public interface IFileSystemProvider
    {
        public Task<FileDetail> SaveFileAsync (ArchiveFile archiveFile);
        public ArchiveFile GetFileEntity (string path);
        public Task DeleteFileEntity (string path);
        public Task<FileDetail> UpdateFileName (string path, string newName);
        public Task<FileDetail> UpdateFileData (string path, Stream data);
    }
}