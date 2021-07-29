using System.IO;

namespace FileArchive.Models.File.FileModels
{
    public class FileUpdateInfo
    {
        public int Id { get; set; }
        public string NewName { get; set; }
        public bool NewAccess { get; set; }
        public Stream NewData { get; set; }
    }
}