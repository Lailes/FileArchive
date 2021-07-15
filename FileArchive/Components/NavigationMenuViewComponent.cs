using Microsoft.AspNetCore.Mvc;

namespace FileArchive.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}