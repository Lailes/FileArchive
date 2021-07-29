using System;
using System.ComponentModel.DataAnnotations;

namespace FileArchive.Models.File.FileModels
{
    public class FileDetail
    {
        [Key] public int Id { get; set; }

        public string FileName { get; set; }
        public long BytesCount { get; set; }
        public DateTime UploadDateTime { get; set; }
        public string Path { get; set; }
        public string OwnerEmail { get; set; }

        public bool? AllowAnonymus { get; set; } = false;
    }
}