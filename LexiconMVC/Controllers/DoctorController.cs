using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LexiconMVC.Controllers
{
    public class DoctorController : Controller
    {


        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(float fever) // Must corelate to the name that is requering the variable 
                                                     // <input type="number" name="fever" />
        {
            ViewBag.Message = DoctorModel.FeverCheck(fever);
            return View();
        }



    }

}
