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
        // GET api/<UsersController>/5
        [HttpGet("{name}")]
        public bool Get(string name)
        {
            return _userService.NameExist(name);
        }
        // GET api/<UsersController>/5
        [HttpGet()]
        public UserProfileViewModel Get([FromQuery]string name,[FromQuery]string password)
        {
            return _userService.GetUserByName(name, password);
        }

        // POST api/<UsersController>
        [HttpPost]
        public int Post([FromBody] UserViewModel userViewModel)
        {
            int successCode = _userService.AddUser(userViewModel);
            return successCode;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public int Put([FromRoute]int id, [FromBody] UserViewModel userViewModel)
        {
            int successCode = _userService.UpdateUser(id,userViewModel);
            return successCode;
        }

        // DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
