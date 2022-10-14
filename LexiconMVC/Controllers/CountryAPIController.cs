using Microsoft.AspNetCore.Mvc;
using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryAPIController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        public CountryAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CountryAPIController>
        [HttpGet]
        public List<Country> Get()
        {
            var country = _context.Countries.ToList();
            //CityViewModel cvm = new CityViewModel();
            //cvm.CountryList = _context.Countries.ToList();
            return country;
            //return cvm;
        }

        // GET api/<CountryAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
