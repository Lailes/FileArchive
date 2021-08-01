using FileArchive.Models.File.FileModels;
using Microsoft.EntityFrameworkCore;

namespace FileArchive.Models.File
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<FileDetail> FileDetails { get; set; }
    }
}