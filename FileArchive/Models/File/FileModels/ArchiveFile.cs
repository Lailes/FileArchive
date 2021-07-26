using System;
using System.IO;

namespace FileArchive.Models.File.FileModels
{
    public class ArchiveFile: IDisposable
    {
        public string Name { get; init; }
        public Stream Stream { get; init; }
        public string OwnerUserName { get; init; }
        
        public FileDetail Details { get; set; }

        public void Dispose () => Stream?.Dispose();
    }
}