using System;
using Microsoft.AspNetCore.Mvc;

namespace FileArchive
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}