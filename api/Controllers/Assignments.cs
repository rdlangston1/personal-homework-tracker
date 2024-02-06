using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class Assignments : ControllerBase
    {
        // GET: api/<Assignments>
        [HttpGet]
        public List<Assignment> Get()
        {
            AssignmentUtility assignmentUtility = new AssignmentUtility();
            List<Assignment> assignmentsList = new List<Assignment>();
            assignmentsList = assignmentUtility.GetAllAssignments();
            return assignmentsList;
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
