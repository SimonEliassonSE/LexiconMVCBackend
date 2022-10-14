using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; } 
        //public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }

        public List<City> Cities { get; set; } = new List<City>();


    }
}
