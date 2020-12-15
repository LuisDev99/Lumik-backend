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
            var service = _userService.Get();                        

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok(service.Result.Select(user => new UserDTO
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
            var service = _userService.GetByID(id);

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok(new UserDTO
            {
                ID = service.Result.ID,
                Name = service.Result.Name,
                Password = service.Result.Password,
                UserName = service.Result.UserName
            });

        }

        // GET api/<UsersController>/5
        [HttpGet("{id}/grocery-lists", Name ="GetUsersGroceryLists")]
        public ActionResult<IEnumerable<GroceryListDTO>> GetUsersGroceryLists(int id)
        {
            var service = _userService.GetUserGroceryLists(id);

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            var groceryLists = service.Result;

            return Ok(service.Result.Select(list => new GroceryListDTO { 
                ID = list.ID,
                Name = list.Name,
                UserID = list.UserID
            }));

        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] AddUser newUser)
        {
            var service = _userService.Insert(new User { 
                Name = newUser.Name,
                Password = newUser.Password,
                UserName = newUser.UserName
            });

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if(service.ResponseCode == ResponseCode.ImATeaPot)
            {
                return StatusCode(418, service.Error); // I'm A Teapot (Handle if the username already exists)
            }

            return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AddUser newInfo)
        {
            var service = _userService.Update(new User
            {
                ID = id,
                Name = newInfo.Name,
                Password = newInfo.Password,
                UserName = newInfo.UserName
            });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok();

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = _userService.Delete(new User { ID = id });
            
            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if(service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok();
        }
    }
}
