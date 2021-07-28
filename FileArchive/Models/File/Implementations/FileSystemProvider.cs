using System;
using System.IO;
using System.Threading.Tasks;
using FileArchive.Models.File.FileModels;
using FileArchive.Models.File.Interfaces;

namespace FileArchive.Models.File.Implementations
{
    public class FileSystemProvider : IFileSystemProvider
    {
        private readonly FileSystemProviderOptions _options;

        public FileSystemProvider (FileSystemProviderOptions options)
        {
            _options = options;
        }

        public async Task<FileDetail> SaveFileAsync (ArchiveFile archiveFile)
        {
            var folder = Path.Combine(_options.Root, archiveFile.OwnerEmail);

            Directory.CreateDirectory(folder);

            var path = Path.Combine(folder, archiveFile.Name);

            await using var stream = new FileStream(path, FileMode.Create);
            await archiveFile.Stream.CopyToAsync(stream);

            return new FileDetail {
                BytesCount = stream.Length,
                FileName = archiveFile.Name,
                OwnerEmail = archiveFile.OwnerEmail,
                Path = path,
                UploadDateTime = DateTime.Now
            };
        }

        public ArchiveFile GetFileEntity (string path)
        {
            var fileInfo = new FileInfo(path);
            
            if (!fileInfo.Exists)
                throw new FileNotFoundException();
            
            return new ArchiveFile {
                Name = fileInfo.Name,
                Stream = fileInfo.Open(FileMode.Open)
            };
        }

        public async Task DeleteFileEntity (string path)
        {
            await Task.Yield();
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
                throw new FileNotFoundException();
            
            fileInfo.Delete();
        }
    }

    public struct FileSystemProviderOptions
    {
        public string Root { get; set; }
    }
}