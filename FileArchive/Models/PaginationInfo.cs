using System.Collections.Generic;
using FileArchive.Models.File.FileModels;

namespace FileArchive.Models
{
    public class PaginationInfo
    {
        public IEnumerable<FileDetail> FileDetails { get; set; }
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
    }
}