using System;

namespace FileArchive.Models
{
    public class FileDetail
    {
        public string FileName { get; set; }
        public ulong BytesCount { get; set; }
        public DateTime UploadDateTime { get; set; }
        public string OwnerEmail { get; set; }
    }
}