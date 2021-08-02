namespace FileArchive.Models.Account
{
    public interface IUserLevelProvider
    {
        public byte GetStatus (string userEmail);
    }
}