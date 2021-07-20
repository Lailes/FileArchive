namespace FileArchive.Models.Account
{
    public class AccountDetails
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public uint FilesCount { get; set; }
        public ulong TotalBytes { get; set; }
        public uint UploadCount { get; set; }
        public uint DownLoadCount { get; set; }
    }
}