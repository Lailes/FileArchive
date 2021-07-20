#nullable enable
using System.Collections.Generic;

namespace FileArchive.Models
{
    public interface IFileProvider
    {
        public IEnumerable<FileDetail> GetFileDetailsForName(string? name);
    }
}