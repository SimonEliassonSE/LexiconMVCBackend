using Microsoft.AspNetCore.Mvc;
using LexiconMVC.Data;
using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleAPIController : ControllerBase
    {
        readonly ApplicationDbContext _context;


        public PeopleAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<PeopleAPIController>
        [HttpGet]
        public List<Person> Get()
        {
            //PeopleViewModel pvm = new PeopleViewModel();
            //pvm.PeopleList = _context.People.ToList();
            var person = _context.People.ToList();
            //List<Person> personList = new List<Person>();
            //personList = person.ToList();

            return person;
        }

        // GET api/<PeopleAPIController>/5
        [HttpGet("{id}")]
        public List<Person> Get(int id)
        {

            var person = _context.People.FirstOrDefault(x => x.Id == id);
            List<Person> personList = new List<Person>();
            personList.Add(person);
            //return $"{person.Id} {person.Name} {person.Phonenumber} {person.CityId}";
     
            return personList;
        }

        // POST api/<PeopleAPIController>
        [HttpPost]
        public Person Create([FromBody] FetchPostDataViewModel fpd)
        {
            Person p = new Person() { Name = fpd.Name, Phonenumber = fpd.Phonenumber, CityId = fpd.CityId};

            if (p == null)
            {
                Response.StatusCode = 400;
            }


            else
            {
                Response.StatusCode = 201;
                _context.People.Add(p);
                _context.SaveChanges();

            }

            return p;
        }
        //public string Post([FromBody] string value)
        //{
        //    return value;
        //}
        //public Person Create(FetchPostDataViewModel fpdVM)
        //public List<string> Post(List<string> values)
        //{
        //    return values;
        //    //Person p = new Person();            
        //    //p.Name = fpdVM.name;
        //    //int newPhonenumber;
        //    //int.TryParse(fpdVM.phonenumber, out newPhonenumber);
        //    //p.Phonenumber = newPhonenumber;
        //    //int newCityId;
        //    //if (!int.TryParse(fpdVM.cityId, out newCityId)) ;
        //    //p.CityId = newCityId;
        //    //if(p == null)
        //    //{
        //    //    Response.StatusCode = 400;
        //    //}
        //    //else
        //    //{
        //    //    Response.StatusCode = 201;                
        //    //    _context.People.Add(p);
        //    //    _context.SaveChanges();

        //    //}

        //    //return p;

        //    //var isIdtaken = _context.People.FirstOrDefault(x => x.Id == id);
        //    //Console.WriteLine(countryId);

        //    //if(isIdtaken.Id == id)
        //    //{
        //    //    Console.WriteLine("User already exist");
        //    //}

        //    //else
        //    //{

        //    //int newPhonenumber;
        //    //if (!int.TryParse(fpdVM.phonenumber, out newPhonenumber)) ;
        //    //int newCityId;
        //    //if (!int.TryParse(fpdVM.cityId, out newCityId)) ;
        //    //int iD;
        //    //if (!int.TryParse(fpdVM.id, out iD)) ;

        //    //var checkId = _context.People.FirstOrDefault(x => x.Id==iD);

        //    //Person p = new Person();
        //    //if (checkId != null)
        //    //{
        //    //    Response.StatusCode = 450;

        //    //}
        //    //else
        //    //{
        //    //    p.Name = fpdVM.name;
        //    //    p.Phonenumber = newPhonenumber;
        //    //    p.CityId = newCityId;
        //    //    _context.People.Add(p);
        //    //    _context.SaveChanges();
        //    //}

        //    //return p;

        //}

        // PUT api/<PeopleAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PeopleAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == id);

            _context.People.Remove(person);
            _context.SaveChanges();

            //Get();
        }
    }
}
