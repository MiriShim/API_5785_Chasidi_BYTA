
//using DAL;
using BL;
using DAL_Interface;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IGroupBL _bl;
        public UserGroupController(IGroupBL bl)
        {
            _bl = bl;
        }

        //GET: api/<UserGroupController>
        [HttpGet]
        public IEnumerable<UserGroup> Get()
        {           
            return _bl.GetUserGroups();
        }

        // GET api/<UserGroupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserGroupController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserGroupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserGroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
