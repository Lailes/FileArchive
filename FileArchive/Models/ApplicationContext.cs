using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FileArchive.Models
{
    public class ApplicationContext: DbContext, IFileProvider
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
        }

        public  DbSet<FileStoreRecord> FileStoreRecords { get; set; }

        public IEnumerable<FileDetail> FileDetails => 
            FileStoreRecords
                .Select(record => new FileDetail {
                    FileName = Path.GetFileName(record.Name), 
                    UploadDateTime = File.GetCreationTime(record.Path), 
                    BytesCount = (ulong) new FileInfo(record.Path).Length,
                    OwnerEmail = record.OwnerEmail
                }).AsEnumerable();

        public IEnumerable<FileDetail> GetFileDetailsForName(string? name)
        {
            throw new System.NotImplementedException();
        }
    }
}