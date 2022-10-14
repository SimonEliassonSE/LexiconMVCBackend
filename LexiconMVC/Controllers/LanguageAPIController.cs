using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;

namespace LexiconMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageAPIController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        public LanguageAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<LanguageAPIController>
        [HttpGet]
        public List<Language> Get()
        {
            var languages = _context.Languages.ToList();

            return languages;

        }

        // GET api/<LanguageAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LanguageAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LanguageAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LanguageAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
