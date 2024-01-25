using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class Assignments : ControllerBase
    {
        // GET: api/<Assignments>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Assignments>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Assignments>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Assignments>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Assignments>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
