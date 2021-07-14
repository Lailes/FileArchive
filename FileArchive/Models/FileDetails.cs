using System;

namespace FileArchive.Models
{
    public class FileDetails
    {
        public string FileName { get; set; }
        public ulong BytesCount { get; set; }
        public DateTime UploadDateTime { get; set; }
    }
}