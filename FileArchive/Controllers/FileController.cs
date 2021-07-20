using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class FileController : Controller
    {
        
    }
}