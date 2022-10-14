using LexiconMVC.Data;
using LexiconMVC.ViewModels;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace LexiconMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        readonly ApplicationDbContext _context;

        public static List<Country> countryList = new List<Country>();
        public static CreateCountryViewModel ccvm = new CreateCountryViewModel();

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult CountryIndex()
        {            
            countryList = _context.Countries.ToList();
            return View(countryList);
        }

        // Update inte add.
        
        public IActionResult CreateNewCountry()
        {

            ccvm.CountriesList = _context.Countries.ToList();
            //= _context.Countries.ToList();
            return View(ccvm);
            
        }

        [HttpPost]
        public IActionResult CreateNewCountry(CreateCountryViewModel mod)
        {
            if (ModelState.IsValid)
            {
                Country c = new Country();
                c.CountryName = mod.CountryName;
                c.Continent = mod.Continent;
                _context.Countries.Add(c);
                _context.SaveChanges();
            }

            return RedirectToAction("CreateNewCountry");

        }

        public IActionResult DeleteCountryFromList(int id)
        {
            var country = _context.Countries.FirstOrDefault(x => x.Id == id);

            _context.Countries.Remove(country);
            _context.SaveChanges();

            return RedirectToAction("CountryIndex");
        }


        public IActionResult EditCountry(int id)
        {

            var country = _context.Countries.FirstOrDefault(x => x.Id == id);
            Country co = new Country();
            co.Id = country.Id;
            co.CountryName = country.CountryName;
            co.Continent = country.Continent;
            co.Cities = _context.Cities.ToList();

            return View(co);
        }

        [HttpPost]
        public IActionResult EditCountry(Country co, string countryName, string continent)
        {
            Country c = _context.Countries.FirstOrDefault(c => c.Id == co.Id);

            c.CountryName = countryName;
            c.Continent = continent;
            //c.CityName = cvm.CityName;
            _context.Update(c);
            _context.SaveChanges();

            //mod.CCVM.CityName = 

            //var city = _context.Cities.FirstOrDefault(x => x.Id == EditId);
            //_context.Cities.Update(city);
            //_context.SaveChanges();

            return RedirectToAction("CountryIndex");
        }




        //public IActionResult UpdateCityToCountryRelation()
        //{


        //    ViewBag.Cities = new SelectList(_context.Cities, "Id", "CityName");
        //    ViewBag.Countries = new SelectList(_context.Countries, "Id", "CountryName");

        //    var countryQuery = from countries in _context.Countries
        //                       from cities in _context.Cities
        //                       where cities.CountryId == countries.Id
        //                       select new
        //                       {
        //                           CountryId = countries.Id,
        //                           CountryName = countries.CountryName,
        //                           Contitent = countries.Continent,
        //                           CityName = cities.CityName
        //                       };

        //    List<CountryViewModel> allUsers = new List<CountryViewModel>();

        //    foreach (var country in countryQuery)
        //    {
        //        allUsers.Add(new CountryViewModel()
        //        {

        //            Id = country.CountryId,
        //            CountryName = country.CountryName,
        //            Continent = country.Contitent,
        //            CityName = country.CityName


        //        });
        //    }

        //    return View(allUsers);

        //}

        //[HttpPost]
        //public IActionResult UpdateCityToCountryRelation(int cityid, int countryid)
        //{

        //    var country = _context.Countries.FirstOrDefault(c => c.Id == countryid);
        //    var city = _context.Cities.FirstOrDefault(c => c.Id == cityid);

        //    if(ModelState.IsValid)
        //    {
        //        country.Cities.Add(city);
        //        _context.SaveChanges();
        //    }

        //    //var city = _context.Cities.FirstOrDefault(x => x.Id == countryid);
        //    //var country = _context.Countries.FirstOrDefault(x => x.Id == cityid);

        //    //if (ModelState.IsValid)
        //    //{
        //    //    country.Cities.Add(city);
        //    //    _context.SaveChanges();
        //    //}

        //    return RedirectToAction("UpdateCityToCountryRelation");
        //}

        public IActionResult ReturnToPeopleIndex()
        {

            return RedirectToAction("Index", "People");
        }
    }
}
