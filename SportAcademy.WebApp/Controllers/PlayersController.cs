using Microsoft.AspNetCore.Mvc;

namespace SportAcademy.WebApp.Controllers
{
    public class PlayersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
