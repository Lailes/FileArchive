using System;
using System.IO;

namespace FileArchive.Exceptions
{
    public class FileDetailNotfoundException : FileNotFoundException
    {
        public FileDetailNotfoundException ()
        {
        }

        public FileDetailNotfoundException (string? message) : base(message)
        {
        }
    }
}