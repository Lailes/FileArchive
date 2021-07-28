using System;
using System.IO;
using System.Threading.Tasks;

namespace FileArchive.Infrastructure.Extensions
{
    public static class StreamExtensions
    {
        public static async Task<byte[]> ReadArrayAsync (this Stream stream)
        {
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes.AsMemory(0, bytes.Length));
            return bytes;
        }
    }
}