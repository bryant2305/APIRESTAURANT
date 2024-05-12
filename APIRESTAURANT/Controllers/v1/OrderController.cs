using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.Services;
using ApiRestaurant.Core.Application.ViewModels.Dish;
using ApiRestaurant.Core.Application.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace APIRESTAURANT.Controllers.v1
{

    [ApiVersion("1.0")]
    [ApiController]
    public class OrderController : BaseApiController
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(OrderViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _orderService.Add(vm);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
