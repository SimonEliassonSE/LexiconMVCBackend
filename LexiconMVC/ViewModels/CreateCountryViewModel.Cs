using LexiconMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.ViewModels
{
    public class CreateCountryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string Continent { get; set; }

        public List<Country> CountriesList { get; set; } = new List<Country>();
    }
}
