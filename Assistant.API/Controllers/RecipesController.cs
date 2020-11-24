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
            var _recipes = _recipeService.Get();

            if (_recipes.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_recipes.Error);
            }

            return Ok(_recipes.Result.Select(recipe => new RecipeDTO
            {
                ID = recipe.ID,
                Name = recipe.Name
            }));
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public ActionResult<RecipeDTO> Get(int id)
        {
            var _recipe = _recipeService.GetByID(id);

            if (_recipe.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_recipe.Error);
            }

            if(_recipe.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_recipe.Error);
            }

            return Ok(new RecipeDTO
            {
                ID = _recipe.Result.ID,
                Name = _recipe.Result.Name
            });
        }

        // POST api/<RecipesController>
        [HttpPost]
        public ActionResult<RecipeDTO> Post([FromBody] AddRecipe value)
        {
            var _recipe = _recipeService.Insert(new Recipe
            {
                Name = value.Name
            });

            if(_recipe.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_recipe.Error);
            }

            return Ok(new RecipeDTO
            {
                ID = _recipe.Result.ID,
                Name = _recipe.Result.Name
            });
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public ActionResult<RecipeDTO> Put(int id, [FromBody] AddRecipe value)
        {
            var _recipe = _recipeService.Update(new Recipe
            {
                ID = id,
                Name = value.Name,
            });

            if(_recipe.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_recipe.Error);
            }

            if (_recipe.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_recipe.Error);
            }

            return Ok(new RecipeDTO
            {
                ID = _recipe.Result.ID,
                Name = _recipe.Result.Name
            });
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public ActionResult<RecipeDTO> Delete(int id)
        {
            var _recipe = _recipeService.Delete(new Recipe
            {
                ID = id,
            });

            if (_recipe.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_recipe.Error);
            }

            if (_recipe.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_recipe.Error);
            }

            return Ok(new RecipeDTO
            {
                ID = _recipe.Result.ID,
            });
        }
    }
}
