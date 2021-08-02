namespace FileArchive.Models.Account
{
    public class ProfileInfo
    {
        public string UserName { get; set; }
        public int FileCount { get; set; }
        public long UsedBytes { get; set; }
        public string EMail { get; set; }
        public string UserLevel { get; set; }
        public long TotalBytes { get; set; }
    }
}