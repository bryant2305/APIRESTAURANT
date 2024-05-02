using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

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


            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }

        }

    }
}
