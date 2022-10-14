
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.ViewModels
{
    public class FetchPostDataViewModel
    {
        //[Required]
        //public int id { get; set; }

        public string Name { get; set; }

        public int Phonenumber { get; set; }

        public int CityId { get; set; }
        //[Required]
        //public string countryId { get; set; }
    }
}
