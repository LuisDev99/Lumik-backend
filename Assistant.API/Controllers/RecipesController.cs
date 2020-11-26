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
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: api/<RecipesController>
        [HttpGet]
        public ActionResult<IEnumerable<RecipeDTO>> Get()
        {
            var service = _recipeService.Get();

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok(service.Result.Select(recipe => new RecipeDTO
            {
                ID = recipe.ID,
                Name = recipe.Name
            }));
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public ActionResult<RecipeDTO> Get(int id)
        {
            var service = _recipeService.GetByID(id);

            if (service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            if(service.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(service.Error);
            }

            return Ok(new RecipeDTO
            {
                ID = service.Result.ID,
                Name = service.Result.Name
            });
        }

        // POST api/<RecipesController>
        [HttpPost]
        public ActionResult Post([FromBody] AddRecipe value)
        {
            var service = _recipeService.Insert(new Recipe
            {
                Name = value.Name
            });

            if(service.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(service.Error);
            }

            return Ok();
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AddRecipe value)
        {
            var service = _recipeService.Update(new Recipe
            {
                ID = id,
                Name = value.Name,
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

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = _recipeService.Delete(new Recipe
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
