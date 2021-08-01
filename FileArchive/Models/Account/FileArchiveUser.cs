using Microsoft.AspNetCore.Identity;

namespace FileArchive.Models.Account
{
    public class FileArchiveUser : IdentityUser
    {
        public string Name { get; set; }
        public byte Status { get; set; } = 0;
    }
}