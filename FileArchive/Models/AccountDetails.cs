namespace FileArchive.Models
{
    public class AccountDetails
    {
        public string Login { get; set; }
        public uint FilesCount { get; set; }
        public ulong TotalBytes { get; set; }
        public uint UploadCount { get; set; }
        public uint DownLoadCount { get; set; }
    }
}