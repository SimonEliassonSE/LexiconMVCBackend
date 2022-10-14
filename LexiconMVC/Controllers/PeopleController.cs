using Microsoft.AspNetCore.Mvc;
using LexiconMVC.ViewModels;
using LexiconMVC.Models;
using LexiconMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LexiconMVC.Controllers
{

    [Authorize(Roles = "Admin, User")]
    public class PeopleController : Controller
    {
        readonly ApplicationDbContext _context;


        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public static PeopleViewModel pvm = new PeopleViewModel();


        public IActionResult Index()
        {
            pvm.PeopleList = _context.People.Include(x => x.City).ToList();
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "CityName");

            return View(pvm);

        }

        // Span reagerar på finduser?, något stämmer inte riktigt 
        public ActionResult FindUser(PeopleViewModel mod)
        {
            if (!String.IsNullOrEmpty(mod.SearchFilter))
            {
                StringComparison comp = StringComparison.OrdinalIgnoreCase;
                var filteredPeople = pvm.PeopleList
                    .Where(x => x.Name.Contains(mod.SearchFilter, comp) || x.City.CityName.Contains(mod.SearchFilter, comp)).ToList();
                var m = new PeopleViewModel();
                m.PeopleList = filteredPeople;

                return View("Index", m);
            }

            else
            {
                return RedirectToAction("Index");

            }      
        }


        public ActionResult DeleteFromList(int id)
        {

            var person = _context.People.FirstOrDefault(x => x.Id == id);

            _context.People.Remove(person);
            _context.SaveChanges();

            return RedirectToAction("Index");



        }


        [HttpPost]
        public ActionResult AddToList(PeopleViewModel mod, int cityid)
        {

 
            ModelState.Remove("SearchFilter");


            if (ModelState.IsValid)
            {
                Person p = new Person();
                p.Name = mod.PVM.Name;
                p.Phonenumber = mod.PVM.Phonenumber;
                p.CityId = cityid;
                _context.People.Add(p);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditPerson(int id)
        {
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "CityName");
            var person = _context.People.FirstOrDefault(x => x.Id == id);
            PeopleViewModel mod = new PeopleViewModel();
            mod.PVM.Id = person.Id;
            mod.PVM.Name = person.Name;
            mod.PVM.Phonenumber = person.Phonenumber;
            mod.PVM.CityId = person.CityId;
            mod.PeopleList = _context.People.ToList();
            mod.LanguageList = _context.Languages.ToList();

            return View(mod);
        }

        [HttpPost]
        public IActionResult EditPerson(PeopleViewModel mod)
        {
            Person p = _context.People.FirstOrDefault(c => c.Id == mod.PVM.Id);

            p.Name = mod.PVM.Name;
            p.CityId = mod.PVM.CityId;

            _context.Update(p);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult CityIndex()
        {

            return RedirectToAction("CityIndex", "City");
        }

        public IActionResult CountryIndex()
        {
            return RedirectToAction("CountryIndex", "Country");
        }

        public IActionResult LanguageIndex()
        {

            return RedirectToAction("LanguageIndex", "Language");
        }


    }
}
