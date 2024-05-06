using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.Services;
using ApiRestaurant.Core.Application.ViewModels.Ingredients;
using ApiRestaurant.Core.Application.ViewModels.Tables;
using Microsoft.AspNetCore.Mvc;

namespace APIRESTAURANT.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    public class IngredientController : BaseApiController
    {
        private readonly IIngredientService _ingredientService;
        public  IngredientController (IIngredientService ingredientService)
        {
            _ingredientService = ingredientService; 
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(IngredientViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _ingredientService.Add(vm);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int ID , IngredientViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var ingredient = await _ingredientService.GetById(ID);

                if (ingredient == null)
                {
                    return NotFound();
                }
                ingredient.Name = vm.Name;

                await _ingredientService.Update(ingredient ,ID);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("GET")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var mesasList = await _ingredientService.GetAllAsync();

                if (mesasList == null || mesasList.Count == 0)
                {

                    return NotFound();
                }
                return Ok(mesasList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int ID)
        {
            try
            {
                var mesa = await _ingredientService.GetById(ID);

                if (mesa == null)
                {
                    return NotFound();
                }

                return Ok(mesa);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
