using Microsoft.AspNetCore.Mvc;

namespace SportAcademy.WebApp.Controllers
{
    public class MatchesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
