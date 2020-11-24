using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.API.Models;
using Assistant.API.Models.InsertModels;
using Assistant.Core.Entities;
using Assistant.Core.Enums;
using Assistant.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryListsController : ControllerBase
    {
        private readonly IGroceryListService _groceryListService;

        public GroceryListsController(IGroceryListService groceryListService)
        {
            _groceryListService = groceryListService;
        }

        // GET: api/<GroceryListsController>
        [HttpGet]
        public ActionResult<IEnumerable<GroceryListDTO>> Get()
        {
            var _groceryLists = _groceryListService.Get();

            if(_groceryLists.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryLists.Error);
            }

            if(_groceryLists.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_groceryLists.Error);
            }

            return Ok(_groceryLists.Result.Select(groceryList => new GroceryListDTO { 
                ID = groceryList.ID,
                Name = groceryList.Name,
                UserID = groceryList.UserID
            }));            
        }

        // GET api/<GroceryListsController>/5
        [HttpGet("{id}")]
        public ActionResult<GroceryListDTO> Get(int id)
        {
            var _groceryList = _groceryListService.GetByID(id);

            if(_groceryList.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryList.Error);
            }

            if (_groceryList.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryList.Error);
            }

            return Ok(new GroceryListDTO
            {
                ID = _groceryList.Result.ID,
                Name = _groceryList.Result.Name,
                UserID = _groceryList.Result.UserID
            });

        }

        // POST api/<GroceryListsController>
        [HttpPost]
        public ActionResult<GroceryListDTO> Post([FromBody] AddGroceryList value)
        {
            var _groceryList = _groceryListService.Insert(new GroceryList
            {
                Name = value.Name,
                UserID = value.UserID                
            });


            if(_groceryList.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryList.Error);
            }

            return Ok(new GroceryList
            {
                ID = _groceryList.Result.ID,
                Name = _groceryList.Result.Name,
                UserID = _groceryList.Result.UserID
            });
        }

        // PUT api/<GroceryListsController>/5
        [HttpPut("{id}")]
        public ActionResult<GroceryListDTO> Put(int id, [FromBody] AddGroceryList value)
        {
            var _groceryList = _groceryListService.Update(new GroceryList
            {
                ID = id,
                Name = value.Name,
                UserID = value.UserID,                
            });

            if(_groceryList.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryList.Error);
            }

            if (_groceryList.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_groceryList.Error);
            }

            return Ok(new GroceryListDTO
            {
                ID = id,
                Name = value.Name,
                UserID = value.UserID
            });
        }

        // DELETE api/<GroceryListsController>/5
        [HttpDelete("{id}")]
        public ActionResult<GroceryListDTO> Delete(int id)
        {
            var _groceryList = _groceryListService.Delete(new GroceryList
            {
                ID = id,
            });

            if(_groceryList.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryList.Error);
            }

            if(_groceryList.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_groceryList.Error);
            }


            return Ok(new GroceryListDTO
            {
                ID = id,
            });
        }
    }
}
