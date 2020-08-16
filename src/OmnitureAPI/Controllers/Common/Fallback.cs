using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace SocietyCareAPI.Controllers.Common
{
    public class Fallback : Controller
    {
        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), 
                "wwwroot", "index.html"), "text/HTML");
        }

    }
}