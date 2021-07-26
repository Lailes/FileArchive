using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FileArchive.Exceptions;
using FileArchive.Models.File.FileModels;
using FileArchive.Models.File.Interfaces;

namespace FileArchive.Models.File.Implementations
{
    public class FileManager : IFileManager
    {
        private readonly IFileDetailProvider _fileDetailProvider;
        private readonly IFileSystemProvider _fileSystemProvider;

        public FileManager (IFileDetailProvider fileDetailProvider, IFileSystemProvider fileSystemProvider)
        {
            _fileDetailProvider = fileDetailProvider;
            _fileSystemProvider = fileSystemProvider;
        }

        public async Task SaveFile (ArchiveFile archiveFile)
        {
            var info = await _fileSystemProvider.SaveFileAsync(archiveFile);
            await _fileDetailProvider.SaveFileDetailAsync(info);
        }

        public IEnumerable<FileDetail> GetFileDetailsForUser (string userName) => 
            _fileDetailProvider.GetFileDetailForUser(userName);

        public ArchiveFile GetArchiveFileById (int fileId)
        {
            var fileDetail = _fileDetailProvider.GetFileDetailById(fileId);

            if (fileDetail == null)
                throw new FileDetailNotfoundException();
            
            var file = _fileSystemProvider.GetFileEntity(fileDetail.Path);
            file.Details = fileDetail;
            
            return file;
        }
    }
}