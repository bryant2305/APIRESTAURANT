using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.ViewModels.Tables;
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
        private readonly IMesasService _mesasService;

        public MesasController(IMesasService mesasService)
        {
            _mesasService = mesasService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(MesasViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _mesasService.Add(vm);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int ID ,MesasViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var Table = await _mesasService.GetById(ID);

                if (Table == null)
                {
                    return NotFound();
                }

                await _mesasService.Update(Table, ID);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GET")]
        [Authorize(Roles = "Admin,SuperAdmin,Waither")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var mesasList = await _mesasService.GetAllAsync();

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

        [Authorize(Roles = "Admin,SuperAdmin,Waither")]
        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById( int ID)
        {
            try
            {
                var mesa = await _mesasService.GetById(ID);

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

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int ID)
        {
            try
            {
                var mesa = await _mesasService.GetById(ID);

                if (mesa == null ||mesa.ID == 0)
                {
                    return NotFound();
                }
                await _mesasService.Delete(ID);
                return Ok(mesa);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
