using Microsoft.AspNetCore.Mvc;

namespace SportAcademy.WebApp.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
