using LebaneseHomemade.Data.Service;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LebaneseHomemade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UsersController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    List<UserModel> _userList = _userService.GetUsers();
        //    return Ok(_userList);
        //}

        // GET api/<UsersController>/5
        [HttpGet("{name},{password}")]
        public IActionResult Get(string name,string password)
        {
            var _user = _userService.GetUserByName(name,password);
            return Ok(_user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UserViewModel userViewModel)
        {
            _userService.AddUser(userViewModel);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
