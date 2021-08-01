using System.Collections.Generic;

namespace FileArchive.Models.Account
{
    public interface IArchiveUserManager
    {
        public IEnumerable<FileArchiveUser> FileArchiveUsers { get; }
        public byte GetStatus (string userEmail);
    }
}