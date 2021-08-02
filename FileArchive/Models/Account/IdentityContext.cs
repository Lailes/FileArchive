using System.Collections.Generic;
using System.Linq;
using FileArchive.Exceptions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FileArchive.Models.Account
{
    public class IdentityContext : IdentityDbContext<FileArchiveUser>, IUserLevelProvider
    {
        public IdentityContext (DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public byte GetStatus (string userEmail) =>
            Users.AsEnumerable().FirstOrDefault(user => user.UserName == userEmail)?.Status
            ?? throw new UserNotFoundException("Not found: " + userEmail);
    }
}