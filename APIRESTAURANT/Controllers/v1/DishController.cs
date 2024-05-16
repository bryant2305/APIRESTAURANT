using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.Services;
using ApiRestaurant.Core.Application.ViewModels.Dish;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIRESTAURANT.Controllers.v1
{
     [ApiVersion("1.0")]
    [ApiController]
    public class DishController : BaseApiController
    {
        private readonly IDishService _idishService;

        public DishController(IDishService idishService)
        {
            _idishService = idishService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(DishViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _idishService.Add(vm);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GET")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var mesasList = await _idishService.GetAllViewModelWhitInclude();

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

        [HttpGet("GetById/{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByid(int ID)
        {
            try
            {
               DishViewModel mesasList = await _idishService.GetById(ID);

                if (mesasList == null)
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
    }
}
