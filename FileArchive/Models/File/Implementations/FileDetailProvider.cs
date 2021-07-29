using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileArchive.Exceptions;
using FileArchive.Models.File.FileModels;
using FileArchive.Models.File.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            _applicationContext.FileDetails
                               .FirstOrDefault(detail => detail.Id == fileId) 
                                                         ?? throw new FileDetailNotfoundException();

        public async Task DeleteFileDetail (int fileId)
        {
            var detail = GetFileDetailById(fileId);
            
            _applicationContext.FileDetails.Remove(detail);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task UpdateFileDetail (FileDetail fileDetail)
        {
            if (fileDetail.Id == 0)
                throw new ArgumentException("File detail ID in null");

            var detail = GetFileDetailById(fileDetail.Id);

            if (fileDetail.Path != null)
                detail.Path = fileDetail.Path;
            
            
            if (fileDetail.FileName != null)
                detail.FileName = fileDetail.FileName;
            
            if (fileDetail.AllowAnonymus != null)
                detail.AllowAnonymus = fileDetail.AllowAnonymus;

            _applicationContext.Entry(detail).State = EntityState.Modified;
            
            await _applicationContext.SaveChangesAsync();
        }
    }
}
