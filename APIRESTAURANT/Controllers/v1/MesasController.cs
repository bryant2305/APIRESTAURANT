using ApiRestaurant.Core.Application.DTOS.Orders;
using ApiRestaurant.Core.Application.DTOS.Tables;
using ApiRestaurant.Core.Application.Enums;
using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Domain.Entity;
using ApiRestaurant.Infrastucture.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace APIRESTAURANT.Controllers.v1
{
    [ApiVersion("1.0")]
 
    [ApiController]
    public class MesasController : BaseApiController
    {
        private readonly IMesasRepository _mesasRepository;
        private readonly IMapper _mapper;

        public MesasController(IMesasRepository mesasRepository , IMapper mapper)
        {
            _mesasRepository = mesasRepository;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody ]TablesCreateDto dto)
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
               
                dto.Status = (int)TableStatus.Available;

                if (dto.Status < 1 || dto.Status > 3)
                {
                    return BadRequest("PLEASE TYPE A VALID STATUS");
                }


                Mesas model = _mapper.Map<Mesas>(dto);

                await _mesasRepository.AddAsync(model);
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
        public async Task<IActionResult> Update(int ID ,[FromBody] TablesUpdateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var existingTable = await _mesasRepository.GetByIdAsync(ID);
                if (existingTable == null || ID == 0)
                {
                    return NotFound();
                }

                // Actualiza las propiedades de la entidad existente con los valores del DTO
                _mapper.Map(dto, existingTable);


                await _mesasRepository.UpdateAsync(existingTable, ID);
                await _mesasRepository.SaveChangesAsync();
                return Ok(existingTable);
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
                var orderList = await _mesasRepository.GetAllMesasWithOrderAsync();

                if (orderList == null || orderList.Count == 0)
                {

                    return NotFound();
                }

                var responseDto = _mapper.Map<List<TablesDto>>(orderList);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

      //  [Authorize(Roles = "Admin,SuperAdmin,Waither")]
        [HttpGet("GetTableOrdenById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrderById(int ID)
        {
            try
            {
                var mesa = await _mesasRepository.GetOrderAsync(ID);

                if (mesa == null)
                {
                    return NotFound();
                }
                var mesaDto = _mapper.Map<TablesDto>(mesa);

                return Ok(mesaDto);
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
        public async Task<IActionResult> GetById( int ID)
        {
            try
            {
                var mesa = await _mesasRepository.GetByIdAsync(ID);

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


        [HttpPut("ChangeStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeStatus(int ID, [FromBody] ChangeStatusTableDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var existingTable = await _mesasRepository.GetByIdAsync(ID);
                if (existingTable == null || ID == 0)
                {
                    return NotFound();
                }

                if(dto.Status < 1 || dto.Status > 3)
                {
                    return BadRequest("PLEASE TYPE A VALID STATUS");
                }

                // Actualiza las propiedades de la entidad existente con los valores del DTO
                _mapper.Map(dto, existingTable);


                await _mesasRepository.UpdateAsync(existingTable, ID);
                await _mesasRepository.SaveChangesAsync();
                return Ok(existingTable);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int ID)
        {
            try
            {
                var mesa = await _mesasRepository.GetByIdAsync(ID);

                if (mesa == null )
                {
                    return NotFound();
                }
                await _mesasRepository.DeleteAsync(mesa);

                return Ok(mesa);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
