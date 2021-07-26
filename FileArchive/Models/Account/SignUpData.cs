using System.ComponentModel.DataAnnotations;

namespace FileArchive.Models.Account
{
    public class SignUpData
    {
        [Required] public string EMail { get; set; }

        [Required] public string Password { get; set; }

        [Required] public string Name { get; set; }
    }
}