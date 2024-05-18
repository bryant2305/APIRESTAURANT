using ApiRestaurant.Core.Application.DTOS.Dish;
using ApiRestaurant.Core.Application.DTOS.Orders;
using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Domain.Entity;
using ApiRestaurant.Infrastucture.Persistence.Repositories;
using AutoMapper;
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
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public DishController(IDishRepository dishRepository , IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create( [FromBody] DishCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (dto == null)
                {

                    return NotFound();
                }

                Dish model = _mapper.Map<Dish>(dto);
                await _dishRepository.AddAsync(model);

                var DishWithingredients = await _dishRepository.GetADisheWithIngredientsAsync(model.ID);

                var responseDto = _mapper.Map<DishDto>(DishWithingredients);

                return Ok(responseDto);
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
                var dishesList = await _dishRepository.GetAllDishesWithIngredientsAsync();

                if (dishesList == null || dishesList.Count == 0)
                {
                    return NotFound();
                }

                var dishesDtoList = _mapper.Map<List<DishDto>>(dishesList);

                return Ok(dishesDtoList);
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
        public async Task<IActionResult> GetByid(int ID)
        {
            try
            {
               Dish mesasList = await _dishRepository.GetByIdAsync(ID);

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
