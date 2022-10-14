using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public static CityViewModel cvm = new CityViewModel();

        public IActionResult CityIndex()
        {

            cvm.CityList = _context.Cities.Include(x => x.Country).ToList(); 
            return View(cvm);

        }

        

        public IActionResult CreateNewCity()
        {
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "CountryName");

            cvm.CityList = _context.Cities.Include(x => x.Country).ToList(); 
            return View(cvm);
        }

        [HttpPost]
        public ActionResult CreateNewCity(CityViewModel mod, int countryid)
        {

            if (ModelState.IsValid)
            {
                City c = new City();
                c.CityName = mod.CityName;
                c.CountryId = countryid;
                _context.Cities.Add(c);
                _context.SaveChanges();
            }

            return RedirectToAction("CreateNewCity");
        }
        public ActionResult DeleteCityFromList(int id)
        {

            var city = _context.Cities.FirstOrDefault(x => x.Id == id);

            _context.Cities.Remove(city);
            _context.SaveChanges();

            return RedirectToAction("CityIndex");



        }

        public IActionResult EditCity(int id)
        {
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "CountryName");
            var city = _context.Cities.FirstOrDefault(x => x.Id == id);
            CityViewModel cvm = new CityViewModel();
            cvm.Id = city.Id;
            cvm.CountryId = city.CountryId;
            cvm.CityName = city.CityName;
            cvm.CountryList = _context.Countries.ToList();

            return View(cvm);
        }

        [HttpPost]
        public IActionResult EditCity(CityViewModel cvm, int countryId)
        {
            City c = _context.Cities.FirstOrDefault(c => c.Id == cvm.Id);
            
            c.CountryId = countryId;
            c.CityName = cvm.CityName;
            _context.Update(c);
            _context.SaveChanges();

            //mod.CCVM.CityName = 

            //var city = _context.Cities.FirstOrDefault(x => x.Id == EditId);
            //_context.Cities.Update(city);
            //_context.SaveChanges();

            return RedirectToAction("CityIndex");
        }
        public IActionResult ReturnToPeopleIndex()
        {

            return RedirectToAction("Index", "People");
        }

    }


}
