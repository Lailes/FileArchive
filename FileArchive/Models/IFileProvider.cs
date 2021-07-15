using System.Collections.Generic;

namespace FileArchive.Models
{
    public interface IFileProvider
    {
        public IEnumerable<FileDetail> FileDetails { get; }
    }
}