﻿using LebaneseHomemade.Data.Service;
using LebaneseHomemade.Data.ViewModel;
using LebaneseHomemadeLibrary;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet()]
        public UserProfileViewModel Get([FromQuery]string name,[FromQuery]string password)
        {
            return _userService.GetUserByName(name, password);
        }
        [HttpGet("{name}")]
        public string Get([FromRoute] string name)
        {
            return _userService.GetEmailOfUser(name);
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
        // PATCH api/<UsersController>/5
        [HttpPatch("{name}")]
        public int Patch([FromRoute] string name, [FromBody]JsonPatchDocument password)
        {
            var successCode = _userService.ResetPassword(name, password);
            return successCode;
        }
    }
}
