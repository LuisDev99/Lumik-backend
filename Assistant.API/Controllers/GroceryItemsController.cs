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
        [HttpGet(Name = "GetGroceryItems")]
        public ActionResult<IEnumerable<GroceryItemDTO>> Get()
        {
            var service = _groceryItemService.Get();

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Result);
            }

            return Ok(service.Result.Select(groceryItem => new GroceryItemDTO
            {
                ID = groceryItem.ID,
                Name = groceryItem.Name,
                Count = groceryItem.Count,
                GroceryListID = groceryItem.GroceryListID
            }));
        }

        // GET api/<GroceryItemsController>/5
        [HttpGet("{id}", Name = "GetGroceryItem")]
        public ActionResult<GroceryItemDTO> Get(int id)
        {
            var service = _groceryItemService.GetByID(id);            

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok(new GroceryItemDTO
            {
                ID = service.Result.ID,
                Name = service.Result.Name,
                Count = service.Result.Count,                
                GroceryListID = service.Result.GroceryListID
            });

        }

        // POST api/<GroceryItemsController>
        [HttpPost(Name = "AddGroceryItem")]
        public ActionResult Post([FromBody] AddGroceryItem value)
        {
            var service = _groceryItemService.Insert(new GroceryItem
            {
                Name = value.Name,
                Count = value.Count,
                GroceryListID = value.GroceryListID,
            });

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok();
        }

        // PUT api/<GroceryItemsController>/5
        [HttpPut("{id}", Name = "UpdateGroceryItem")]
        public ActionResult Put(int id, [FromBody] AddGroceryItem value)
        {
            var service = _groceryItemService.Update(new GroceryItem
            {
                ID = id,
                Name = value.Name,
                Count = value.Count,
                GroceryListID = value.GroceryListID
            });

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if (service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok();
        }

        // DELETE api/<GroceryItemsController>/5
        [HttpDelete(Name = "DeleteGroceryItem")]
        public ActionResult Delete([FromBody] GroceryItemDTO groceryItem)
        {
            var service = _groceryItemService.Delete(
                new GroceryItem { ID = groceryItem.ID, GroceryListID = groceryItem.GroceryListID });

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok();
        }
    }
}
