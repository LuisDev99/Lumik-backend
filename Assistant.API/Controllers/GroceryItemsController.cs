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
    public class GroceryItemsController : ControllerBase
    {
        private readonly IGroceryItemService _groceryItemService;

        public GroceryItemsController(IGroceryItemService groceryItemService)
        {
            _groceryItemService = groceryItemService;
        }

        // GET: api/<GroceryItemsController>
        [HttpGet]
        public ActionResult<IEnumerable<GroceryItemDTO>> Get()
        {
            var _groceryItems = _groceryItemService.Get();

            if (_groceryItems.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryItems.Result);
            }

            return Ok(_groceryItems.Result.Select(item => new GroceryItemDTO
            {
                ID = item.ID,
                Name = item.Name,
                Count = item.Count,
                GroceryListID = item.GroceryListID
            }));
        }

        // GET api/<GroceryItemsController>/5
        [HttpGet("{id}")]
        public ActionResult<GroceryItemDTO> Get(int id)
        {
            var _groceryItem = _groceryItemService.GetByID(id);

            if(_groceryItem.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_groceryItem.Error);
            }

            if (_groceryItem.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryItem.Error);
            }

            return Ok(new GroceryItemDTO
            {
                ID = _groceryItem.Result.ID,
                Name = _groceryItem.Result.Name,
                Count = _groceryItem.Result.Count,                
                GroceryListID = _groceryItem.Result.GroceryListID
            });

        }

        // POST api/<GroceryItemsController>
        [HttpPost]
        public ActionResult<GroceryItemDTO> Post([FromBody] AddGroceryItem value)
        {
            var _groceryItem = _groceryItemService.Insert(new GroceryItem
            {
                Name = value.Name,
                Count = value.Count,
                GroceryListID = value.GroceryListID,
            });

            if(_groceryItem.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryItem.Error);
            }

            return Ok(new GroceryItemDTO
            {
                ID = _groceryItem.Result.ID,
                Name = _groceryItem.Result.Name,
                Count = _groceryItem.Result.Count,
                GroceryListID = _groceryItem.Result.GroceryListID
            });
        }

        // PUT api/<GroceryItemsController>/5
        [HttpPut("{id}")]
        public ActionResult<GroceryItemDTO> Put(int id, [FromBody] AddGroceryItem value)
        {
            var _groceryItem = _groceryItemService.Update(new GroceryItem
            {
                ID = id,
                Name = value.Name,
                Count = value.Count,
                GroceryListID = value.GroceryListID
            });

            if(_groceryItem.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryItem.Error);
            }

            if (_groceryItem.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_groceryItem.Error);
            }

            return Ok(new GroceryItemDTO
            {
                ID = id,
                Name = value.Name,
                Count = value.Count,                
                GroceryListID = value.GroceryListID,
            });
        }

        // DELETE api/<GroceryItemsController>/5
        [HttpDelete("{id}")]
        public ActionResult<GroceryItemDTO> Delete(int id)
        {
            var _groceryItem = _groceryItemService.Delete(new GroceryItem { ID = id });

            if (_groceryItem.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_groceryItem.Error);
            }

            if (_groceryItem.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_groceryItem.Error);
            }

            return Ok(new GroceryItemDTO
            {
                ID = id
            });
        }
    }
}
