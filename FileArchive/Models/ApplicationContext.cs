using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FileArchive.Models
{
    public class ApplicationContext: DbContext, IFileProvider
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
        }

        public DbSet<FileStoreRecord> FileStoreRecords { get; set; }

        public Task<IEnumerable<FileDetails>> GetFilesForUserAsync(string userName) =>
            Task.Run(() =>
            {
                return FileStoreRecords
                    .Where(record => record.OwnerName == userName)
                    .Select(record => new FileDetails {
                        FileName = Path.GetFileName(record.Name),
                        UploadDateTime = File.GetCreationTime(record.Path),
                        BytesCount = (ulong) new FileInfo(record.Path).Length
                    })
                    .AsEnumerable();
            });

    }
}