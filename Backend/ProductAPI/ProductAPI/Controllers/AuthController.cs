using DAL.Interfaces;
using DAL.Models;
using DAL.Request_Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public AuthController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

       
        // POST api/<AuthController>
        [HttpPost]
        public string Login([FromBody] LoginRequest loginModel)
        {
            return _authentication.Login(loginModel);
        }

        // PUT api/<AuthController>/5
       /* [HttpPost("AddUser")]
        public User AddUser([FromBody] User value)
        {
            return _authentication.AddUser(value);
        }*/
    }
}
