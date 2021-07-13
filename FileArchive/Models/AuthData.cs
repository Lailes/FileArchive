using System.ComponentModel.DataAnnotations;

namespace FileArchive.Models
{
    public class AuthData
    {
        [Required] public string LogIn { get; set; }
        [Required] public string Password { get; set; }
    }
}