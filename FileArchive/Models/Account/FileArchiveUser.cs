using Microsoft.AspNetCore.Identity;

namespace FileArchive.Models.Account
{
    public class FileArchiveUser : IdentityUser
    {
        public string Name { get; set; }
        public Status Status { get; set; } = Status.Level0;
    }

    public enum Status : byte
    {
        Level0
    }
}