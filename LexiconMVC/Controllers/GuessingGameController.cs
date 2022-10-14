using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LexiconMVC.Controllers
{
    public class GuessingGameController : Controller
    {
        public IActionResult Guessing()
        {


            if (HttpContext.Session.GetInt32("Session") != null)
            {
                return View();
            }

            else
            {
                int randomNumber = GuessingGameModel.RandGenerator();
                HttpContext.Session.SetInt32("Session", randomNumber);                
                return View();
            }


        }

        // This aint perfect, but it dose match the input with my variabel in session and changes it if the geuss is correct. However work in progress still. 
        [HttpPost]
        public IActionResult Guessing(int input)
        {

            if (HttpContext.Session.GetInt32("Session") == input)
            {
                ViewBag.Message = "Your geuss was [" + input + "], that was the correct geuss!";
                int randomNumber = GuessingGameModel.RandGenerator();
                HttpContext.Session.SetInt32("Session", randomNumber);
            }

            else if (HttpContext.Session.GetInt32("Session") > input)
            {
                ViewBag.Message = "Your geuss was [" + input + "], that was to smal!";
            }

            else if (HttpContext.Session.GetInt32("Session") < input)
            {
                ViewBag.Message = "Your geuss was [" + input + "], that was to big!";
            }

            return View();
        }
    }
}
