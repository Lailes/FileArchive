using System;
using System.IO;
using System.Threading.Tasks;
using FileArchive.Exceptions;
using FileArchive.Models.File.FileModels;
using FileArchive.Models.File.Interfaces;

namespace FileArchive.Models.File.Implementations
{
    public class FileSystemProvider : IFileSystemProvider
    {
        private readonly FileSystemProviderOptions _options;

        public FileSystemProvider (FileSystemProviderOptions options) => _options = options;

        public async Task<FileDetail> SaveFileAsync (ArchiveFile archiveFile)
        {
            var folder = Path.Combine(_options.Root, archiveFile.OwnerEmail);

            Directory.CreateDirectory(folder);

            var path = Path.Combine(folder, archiveFile.Name);
            
            await using var stream = new FileStream(path, FileMode.Create);
            await archiveFile.Stream.CopyToAsync(stream);
            await archiveFile.Stream.DisposeAsync();
            
            return new FileDetail {
                BytesCount = stream.Length,
                FileName = archiveFile.Name,
                OwnerEmail = archiveFile.OwnerEmail,
                Path = path,
                UploadDateTime = DateTime.UtcNow
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

        public async Task<FileDetail> UpdateFileName (string path, string newName)
        {
            await Task.Yield();

            var fileInfo = new FileInfo(path);
            
            if (fileInfo.Directory == null)
                throw new DirectoryNotFoundException();

            var newFilePath = Path.Combine(fileInfo.Directory.FullName, newName);
            
            if (System.IO.File.Exists(newFilePath))
                throw new FileAlreadyExistsException();

            System.IO.File.Move(path, newFilePath);
            
            return new FileDetail {
                Path = newFilePath,
                FileName = newName,
                UploadDateTime = DateTime.Now
            };
        }
        public async Task<FileDetail> UpdateFileData (string path, Stream data)
        {
            await using var fileStream = new FileStream(path, FileMode.Truncate);
            await data.CopyToAsync(fileStream);
            
            return new FileDetail {
                BytesCount = data.Length,
                UploadDateTime = DateTime.Now
            };
        }
    }

    public record FileSystemProviderOptions(string Root);
}