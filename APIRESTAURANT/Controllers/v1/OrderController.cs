using ApiRestaurant.Core.Application.DTOS.Orders;
using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Domain.Entity;
using ApiRestaurant.Infrastucture.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIRESTAURANT.Controllers.v1
{

    [ApiVersion("1.0")]
    [Authorize(Roles = "SuperAdmin,Waither")]
    [ApiController]
    public class OrderController : BaseApiController
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository , IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody]OrderCreateDto dto)
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

                var order = _mapper.Map<Order>(dto);

                await _orderRepository.AddAsync(order);

                var orderWithDishes = await _orderRepository.GetOrderWithDishesAsync(order.ID);

                var responseDto = _mapper.Map<OrderDto>(orderWithDishes);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
