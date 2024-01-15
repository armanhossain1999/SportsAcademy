using Microsoft.AspNetCore.Mvc;

namespace SportAcademy.WebApp.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
