using Microsoft.AspNetCore.Mvc;

namespace LexiconMVC.Controllers
{
    public class ViewContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        public IActionResult projects()
        {
            return View();
        }
    }
}
