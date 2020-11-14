using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.API.Models;
using Assistant.API.Models.InsertModels;
using Assistant.Core.Entities;
using Assistant.Core.Enums;
using Assistant.Core.Interfaces;
using Assistant.Core.Services;
using Assistant.Infraestructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            var users = _userService.Get();

            if(users.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(users.Error);
            }            

            return Ok(users.Result.Select(user => new UserDTO
            {
                ID = user.ID,
                Name = user.Name,
                Password = user.Password,
                UserName = user.UserName
            }));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _userService.GetByID(id);

            if (user.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(user.Error);
            }

            return Ok(new UserDTO
            {
                ID = user.Result.ID,
                Name = user.Result.Name,
                Password = user.Result.Password,
                UserName = user.Result.UserName
            });

        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] AddUser newUser)
        {
            var _newUser = _userService.Insert(new User { 
                Name = newUser.Name,
                Password = newUser.Password,
                UserName = newUser.UserName
            });

            if(_newUser.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_newUser.Error);
            }

            return Ok(new UserDTO
            {
                ID = _newUser.Result.ID,
                Name = _newUser.Result.Name,
                Password = _newUser.Result.Password,
                UserName = _newUser.Result.UserName
            });
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
