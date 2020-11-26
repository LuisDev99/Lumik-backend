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
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET: api/<IngredientsController>
        [HttpGet]
        public ActionResult<IEnumerable<IngredientDTO>> Get()
        {
            var service = _ingredientService.Get();

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok(service.Result.Select(ingredient => new IngredientDTO
            {
                ID = ingredient.ID,
                Name = ingredient.Name,
                RecipeID = ingredient.RecipeID
            }));
        }

        // GET api/<IngredientsController>/5
        [HttpGet("{id}")]
        public ActionResult<IngredientDTO> Get(int id)
        {
            var service = _ingredientService.GetByID(id);

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if(service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok(new IngredientDTO
            {
                ID =  service.Result.ID,
                Name = service.Result.Name,
                RecipeID = service.Result.RecipeID
            });
        }

        // POST api/<IngredientsController>
        [HttpPost]
        public ActionResult Post([FromBody] AddIngredient value)
        {
            var service = _ingredientService.Insert(new Ingredient
            {
                Name = value.Name,
                RecipeID = value.RecipeID
            });

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok();
        }

        // PUT api/<IngredientsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AddIngredient value)
        {
            var service = _ingredientService.Update(new Ingredient
            {
                ID = id,
                Name = value.Name,
                RecipeID = value.RecipeID
            });

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

        // DELETE api/<IngredientsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = _ingredientService.Delete(new Ingredient
            {
                ID = id
            });

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
