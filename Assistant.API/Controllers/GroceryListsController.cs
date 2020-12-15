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
        [HttpGet(Name = "GetGroceryLists")]
        public ActionResult<IEnumerable<GroceryListDTO>> Get()
        {
            var service = _groceryListService.Get();

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok(service.Result.Select(groceryList => new GroceryListDTO
            {
                ID = groceryList.ID,
                Name = groceryList.Name,
                UserID = groceryList.UserID
            }));
        }

        // GET api/<GroceryListsController>/5
        [HttpGet("query", Name = "GetGroceryListByName")]
        public ActionResult<GroceryListDTO> Get([FromQuery] string name)
        {
            var service = _groceryListService.GetGroceryListByName(name);

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok(new GroceryListDTO
            {
                ID = service.Result.ID,
                Name = service.Result.Name,
                UserID = service.Result.UserID,
                GroceryItems = service.Result.GroceryItems.Select(item => new GroceryItemDTO
                {
                    ID = item.ID,
                    Name = item.Name,
                    Count = item.Count,
                    GroceryListID = item.GroceryListID,
                })
            });
        }

        // GET api/<GroceryListsController>/5
        [HttpGet("{id}/items", Name = "GetGroceryListItems")]
        public ActionResult<IEnumerable<GroceryItemDTO>> GetGroceryListItems(int id)
        {
            var service = _groceryListService.GetGroceryListItems(id);

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            var groceryListItems = service.Result;

            return Ok(groceryListItems.Select(item => new GroceryItemDTO
            {
                ID = item.ID,
                Name = item.Name,
                Count = item.Count,
                GroceryListID = item.GroceryListID
            }));
        }

        // GET api/<GroceryListsController>/5
        [HttpGet("{id}/item", Name = "GetGroceryListItemByName")]
        public ActionResult<GroceryItemDTO> GetGroceryListItemByName(int id, [FromQuery] string itemName)
        {
            var service = _groceryListService.GetGroceryListItemByName(id, itemName);

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            var item = service.Result;

            return Ok(new GroceryItemDTO
            {
                ID = item.ID,
                Name = item.Name,
                Count = item.Count,
                GroceryListID = item.GroceryListID
            });
        }

        // POST api/<GroceryListsController>
        [HttpPost(Name = "CreateGroceryList")]
        public ActionResult Post([FromBody] AddGroceryList value)
        {
            var service = _groceryListService.Insert(new GroceryList
            {
                Name = value.Name,
                UserID = value.UserID
            });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok();
        }

        // PUT api/<GroceryListsController>/5
        [HttpPut("{id}", Name = "UpdateGroceryList")]
        public ActionResult Put(int id, [FromBody] AddGroceryList value)
        {
            var service = _groceryListService.Update(new GroceryList
            {
                ID = id,
                Name = value.Name,
                UserID = value.UserID,
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

        // DELETE api/<GroceryListsController>/5
        [HttpDelete("{id}", Name = "DeleteGroceryList")]
        public ActionResult Delete(int id)
        {
            var service = _groceryListService.Delete(new GroceryList
            {
                ID = id,
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
    }
}
