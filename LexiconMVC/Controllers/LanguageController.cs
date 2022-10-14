using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace LexiconMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguageController : Controller
    {

        readonly ApplicationDbContext _context;

        public static LanguageViewModel lvm = new LanguageViewModel();


        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult LanguageIndex()
        {
           
            lvm.LanguageList = _context.Languages.ToList();


            return View(lvm);

        }



        public IActionResult CreateNewLanguage()
        {

            lvm.LanguageList = _context.Languages.ToList();

            return View(lvm);
        }

        [HttpPost]
        public IActionResult CreateNewLanguage(LanguageViewModel mod)
        {
            if (ModelState.IsValid)
            {
                Language l = new Language();
                l.LanguageName = mod.LanguageName;
                _context.Languages.Add(l);
                _context.SaveChanges();

            }

            return RedirectToAction("CreateNewLanguage");
        }

        public IActionResult DeleteLanguageFromList(int id)
        {
            var language = _context.Languages.FirstOrDefault(x => x.Id == id);

            _context.Languages.Remove(language);
            _context.SaveChanges();

            return RedirectToAction("LanguageIndex");
        }


        public IActionResult EditLanguage(int id)
        {
            var language = _context.Languages.FirstOrDefault(x => x.Id == id);

            Language la = new Language();
            la.Id = language.Id;
            la.LanguageName = language.LanguageName;
            la.PeopleList = _context.People.ToList();

            return View(la);
        }

        [HttpPost]
        public IActionResult EditLanguage(Language la, string languageName)
        {
            Language l = _context.Languages.FirstOrDefault(l => l.Id == la.Id);

            l.LanguageName = languageName;
            _context.Update(l);
            _context.SaveChanges();

            return RedirectToAction("LanguageIndex");
        }



        public IActionResult AddLanguageToPerson()
        {
            ViewBag.People = new SelectList(_context.People, "Id", "Name");
            ViewBag.Languages = new SelectList(_context.Languages, "Id", "LanguageName");

            
            return View();
        }

        
        [HttpPost]   
        public IActionResult AddLanguageToPerson(int personid, int languageid)
        {

            List<Person> people = _context.People.Include(x => x.LanguagesList).ToList();

            var person = _context.People.FirstOrDefault(x => x.Id == personid);
            var language = _context.Languages.FirstOrDefault(x => x.Id == languageid);



            foreach (var aPerson in people)
            {
                if (aPerson.Id == personid)
                {
                    foreach (var aLanguage in aPerson.LanguagesList)
                    {
                        if (aLanguage.Id == languageid)
                        {
                            return RedirectToAction("LanguageIndex");
                        }
                    }
                }
            }

            if (ModelState.IsValid)
            {

                person.LanguagesList.Add(language);
                _context.SaveChanges();

            }

            return RedirectToAction("AddLanguageToPerson");

        }
        public IActionResult ReturnToPeopleIndex()
        {

            return RedirectToAction("Index", "People");
        }

    }
}
