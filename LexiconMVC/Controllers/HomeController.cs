using Microsoft.AspNetCore.Mvc;

namespace LexiconMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
