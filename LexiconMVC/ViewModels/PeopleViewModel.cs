using LexiconMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.ViewModels
{
    public class PeopleViewModel
    {
        public PeopleViewModel()
        {
            PVM = new PersonViewModel();
  
        }
        public string SearchFilter { get; set; }

        public List<Language> LanguageList { get; set; } = new List<Language>();

        public List<Person> PeopleList { get; set; } = new List<Person>();

        public PersonViewModel PVM { get; set; }
    }
}
