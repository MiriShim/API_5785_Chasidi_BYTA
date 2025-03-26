using CS_BYTA_201;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public List <User > Get()
        {
            using ShimonovichUserAccountsContext context = new();

            return context.Users.ToList ()  ;
        }

        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public User? Get(int userId)
        {
            using ShimonovichUserAccountsContext context = new();
            return context.Users.Find(userId);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User newUser)
        {
            using ShimonovichUserAccountsContext context = new();
            context.Users.Add(newUser);
            context.SaveChanges();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
