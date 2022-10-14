using Microsoft.AspNetCore.Mvc;
using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityAPIController : ControllerBase
    {

        readonly ApplicationDbContext _context;
        public CityAPIController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<CityAPIController>
        [HttpGet]
        public List<City> Get()
        {
            var citys = _context.Cities.ToList();
            
            return citys;
        }

        // GET api/<CityAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CityAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CityAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CityAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
