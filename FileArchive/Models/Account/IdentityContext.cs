using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FileArchive.Models.Account
{
    public class IdentityContext : IdentityDbContext<FileArchiveUser>
    {
        public IdentityContext (DbContextOptions<IdentityContext> options) : base(options)
        {
        }
    }
}