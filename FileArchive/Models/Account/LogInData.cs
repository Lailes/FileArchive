using System.ComponentModel.DataAnnotations;

namespace FileArchive.Models.Account
{
    public class LogInData
    {
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}