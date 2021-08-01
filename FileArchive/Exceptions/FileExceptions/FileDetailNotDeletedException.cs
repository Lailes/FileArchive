using System;

namespace FileArchive.Exceptions
{
    public class FileDetailNotDeletedException: FileDetailNotfoundException
    {
        public FileDetailNotDeletedException ()
        {
        }

        public FileDetailNotDeletedException (string? message) : base(message)
        {
        }
    }
}