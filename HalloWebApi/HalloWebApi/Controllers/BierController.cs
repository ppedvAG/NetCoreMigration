using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HalloWebApi.Controllers
{
    public class Bier
    {
        public string Brauerei { get; set; }
        public string Sorte { get; set; }
        public double Alk { get; set; }
        public int Id { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class BierController : ControllerBase
    {
        static List<Bier> db = new List<Bier>();
        static BierController()
        {
            db.Add(new Bier() { Id = 1, Brauerei = "Welde", Sorte = "Helles", Alk = 5.2 });
            db.Add(new Bier() { Id = 2, Brauerei = "Radeberger", Sorte = "Pilsener", Alk = 4.8 });
        }

        // GET: api/<BierController>
        [HttpGet]
        public IEnumerable<Bier> Get()
        {
            return db;
        }

        // GET api/<BierController>/5
        [HttpGet("{id}")]
        public Bier Get(int id)
        {
            return db.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<BierController>
        [HttpPost]
        public void Post([FromBody] Bier einBier)
        {
            db.Add(einBier);
        }

        // PUT api/<BierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Bier value)
        {
            Delete(id);

            value.Id = id;
            Post(value);
        }

        // DELETE api/<BierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Remove(db.FirstOrDefault(x => x.Id == id));
        }
    }
}
