using Microsoft.AspNetCore.Mvc;

namespace SportAcademy.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
