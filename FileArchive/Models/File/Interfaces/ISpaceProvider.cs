namespace FileArchive.Models.File.Interfaces
{
    public interface ISpaceProvider
    {
        public long GetSpaceForStatus (byte status);
        public string GetStringDescription (byte status);
        public ISpaceProvider AddStatus (ArchiveUserStatus status);
    }

    public record ArchiveUserStatus(string Name, byte Status, long BytesCount);
}