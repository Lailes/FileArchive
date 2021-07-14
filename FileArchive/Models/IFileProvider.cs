using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileArchive.Models
{
    public interface IFileProvider
    {
        Task<IEnumerable<FileDetails>> GetFilesForUserAsync(string userName);
    }
}