using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
    public class Person
    {

        [Key]
        public int Id { get; set; } 
        //public string SSN { get; set; }
     
        public string Name { get; set; }

        public int Phonenumber { get; set; }

        // istället för CityID string
        public int CityId { get; set; }
        //public string CityID { get; set; }  

        public City City { get; set; }       

        public List<Language> LanguagesList { get; set; } = new List<Language>();

    }
}
