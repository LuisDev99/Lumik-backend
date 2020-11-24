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
            var _ingredients = _ingredientService.Get();

            if(_ingredients.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_ingredients.Error);
            }

            return Ok(_ingredients.Result.Select(ingredient => new IngredientDTO
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
            var _ingredient = _ingredientService.GetByID(id);

            if(_ingredient.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_ingredient.Error);
            }

            if(_ingredient.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_ingredient.Error);
            }

            return Ok(new IngredientDTO
            {
                ID =  _ingredient.Result.ID,
                Name = _ingredient.Result.Name,
                RecipeID = _ingredient.Result.RecipeID
            });
        }

        // POST api/<IngredientsController>
        [HttpPost]
        public ActionResult<IngredientDTO> Post([FromBody] AddIngredient value)
        {
            var _ingredient = _ingredientService.Insert(new Ingredient
            {
                Name = value.Name,
                RecipeID = value.RecipeID
            });

            if(_ingredient.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_ingredient.Error);
            }

            return Ok(new IngredientDTO
            {
                ID = _ingredient.Result.ID,
                Name = value.Name,
                RecipeID = value.RecipeID
            });
        }

        // PUT api/<IngredientsController>/5
        [HttpPut("{id}")]
        public ActionResult<IngredientDTO> Put(int id, [FromBody] AddIngredient value)
        {
            var _ingredient = _ingredientService.Update(new Ingredient
            {
                ID = id,
                Name = value.Name,
                RecipeID = value.RecipeID
            });

            if(_ingredient.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_ingredient.Error);
            }

            if(_ingredient.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_ingredient.Error);
            }

            return Ok(new IngredientDTO
            {
                ID =  id,
                Name = value.Name,
                RecipeID = value.RecipeID
            });

        }

        // DELETE api/<IngredientsController>/5
        [HttpDelete("{id}")]
        public ActionResult<IngredientDTO> Delete(int id)
        {
            var _ingredient = _ingredientService.Delete(new Ingredient
            {
                ID = id
            });


            if(_ingredient.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_ingredient.Error);
            }

            if(_ingredient.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_ingredient.Error);
            }

            return Ok(new IngredientDTO
            {
                ID = id
            });
        }
    }
}
