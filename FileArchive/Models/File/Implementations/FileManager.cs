using System;
using System.Collections.Generic;
using System.Linq;
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

        public ArchiveFile GetArchiveFileByGuid(Guid guid)
        {
            var fileDetail = _fileDetailProvider.GetFileDetailByGuid(guid);

            if (fileDetail == null)
                throw new FileDetailNotfoundException();
            
            var file = _fileSystemProvider.GetFileEntity(fileDetail.Path);
            file.Details = fileDetail;
            
            return file;
        }

        public async Task DeleteArchiveFileByIdAsync (int fileId)
        {
            var file = _fileDetailProvider.GetFileDetailById(fileId);
            
            var t1 = _fileSystemProvider.DeleteFileEntity(file.Path);
            var t2 = _fileDetailProvider.DeleteFileDetail(file.Id);
            await Task.WhenAll(t1, t2);
        }

        public async Task UpdateArchiveFileAsync (FileUpdateInfo info)
        {
            var detail = _fileDetailProvider.GetFileDetailById(info.Id);

            var tasks = new List<Task>();

            if (info.NewName != null)
                tasks.Add(_fileDetailProvider.UpdateFileDetail(await _fileSystemProvider.UpdateFileName(detail.Path, info.NewName)));
            
            if (info.NewData != null)
                tasks.Add(_fileDetailProvider.UpdateFileDetail(await _fileSystemProvider.UpdateFileData(detail.Path, info.NewData)));

            if (detail.AllowAnonymusId != info.NewAccess)
                tasks.Add(_fileDetailProvider.UpdateFileDetail(new FileDetail {Id = detail.Id, AllowAnonymusId = info.NewAccess}));

            await Task.WhenAll(tasks);
        }

        public bool VerifyOwner (int fileId, string userName) =>
            _fileDetailProvider.GetFileDetailById(fileId).OwnerEmail == userName;

        public Task<long> GetUsedBytesAsync (string userEmail) =>
            Task.Run(() =>
            {
                return _fileDetailProvider.GetFileDetailForUser(userEmail)
                                          .Select(detail =>
                                           {
                                               using var file = _fileSystemProvider.GetFileEntity(detail.Path);
                                               return file.Stream.Length;
                                           })
                                          .Sum();
            });
    }
}