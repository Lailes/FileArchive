using System.Collections.Generic;
using FileArchive.Models.File.Interfaces;

namespace FileArchive.Models.File.Implementations
{
    public class SpaceProvider: ISpaceProvider
    {
        private readonly Dictionary<byte, ArchiveUserStatus> _spaces = new ();

        public long GetSpaceForStatus (byte status) => _spaces[status].BytesCount;

        public string GetStringDescription (byte status) => _spaces[status].Name;

        public ISpaceProvider AddStatus (ArchiveUserStatus status)
        {
            _spaces[status.Status] = status;
            return this;
        }

        public ISpaceProvider AddStatus (string name, byte status, long bytesCount) =>
            AddStatus(new(name, status, bytesCount));
    }
}