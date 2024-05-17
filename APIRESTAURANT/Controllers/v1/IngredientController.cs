using ApiRestaurant.Core.Application.DTOS;
using ApiRestaurant.Core.Application.DTOS.Ingredients;
using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Domain.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIRESTAURANT.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    public class IngredientController : BaseApiController
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public  IngredientController (IIngredientRepository ingredientRepository , IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Create([FromBody]IngredientCreateDto vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (vm == null)
                {
                    return NotFound();
                }
                Ingredient model = _mapper.Map<Ingredient>(vm);

                await _ingredientRepository.AddAsync(model);

                
                return Ok(model);
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
        public async Task<IActionResult> Update(int ID , [FromBody] IngredientUpdateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingIngredient = await _ingredientRepository.GetByIdAsync(ID);
                if (existingIngredient == null || ID == 0)
                {
                    return NotFound();
                }

                // Actualiza las propiedades de la entidad existente con los valores del DTO
                _mapper.Map(dto, existingIngredient);


                await _ingredientRepository.UpdateAsync(existingIngredient , ID);
                await _ingredientRepository.SaveChangesAsync();
                return Ok(existingIngredient);
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
        public async Task<ActionResult> Get()
        {
            try
            {
                var mesasList = await _ingredientRepository.GetAllAsync();

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
                var mesa = await _ingredientRepository.GetByIdAsync(ID);

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
