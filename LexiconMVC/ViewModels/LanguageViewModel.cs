using LexiconMVC.Models;

namespace LexiconMVC.ViewModels
{
    public class LanguageViewModel
    {
        
        public int Id { get; set; }
   
        public string LanguageName { get; set; }

        public List<Language> LanguageList { get; set; } = new List<Language>();
        public List<Person> PeopleList { get; set; } = new List<Person>();

    }
}
