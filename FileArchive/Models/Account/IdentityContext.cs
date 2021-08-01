using System.Collections.Generic;
using System.Linq;
using FileArchive.Exceptions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FileArchive.Models.Account
{
    public class IdentityContext : IdentityDbContext<FileArchiveUser>, IArchiveUserManager
    {
        public IdentityContext (DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public IEnumerable<FileArchiveUser> FileArchiveUsers => Users.AsEnumerable();

        public byte GetStatus (string userEmail) =>
            FileArchiveUsers.FirstOrDefault(user => user.UserName == userEmail)?.Status
            ?? throw new UserNotFoundException("Not found: " + userEmail);
    }
}