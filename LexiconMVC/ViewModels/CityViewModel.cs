using LexiconMVC.Models;

using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.ViewModels

{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public int CountryId { get; set; }

        public List<City> CityList { get; set; } = new List<City>();
     
        public List<Country> CountryList { get; set; } = new List<Country>();

    }
}
