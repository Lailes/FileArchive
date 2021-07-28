using System;
using System.IO;
using System.Threading.Tasks;

namespace FileArchive.Models.File.FileModels
{
    public class ArchiveFile: IDisposable, IAsyncDisposable
    {
        public string Name { get; init; }
        public Stream Stream { get; init; }
        public string OwnerEmail { get; init; }
        public FileDetail Details { get; set; }

        public void Dispose () => Stream?.Dispose();
        public async ValueTask DisposeAsync () => await Stream.DisposeAsync();
    }
}