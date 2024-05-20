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
        public async Task<IActionResult> Create([FromBody] OrderCreateDto dto)
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

                // Añadir la entidad Order a la base de datos
                await _orderRepository.AddAsync(order);


              var orderDish = await _orderRepository.GetOrderWithDishesAsync(order.ID);
          
                var responseDto = _mapper.Map<OrderDto>(orderDish);

                return Ok(responseDto);
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
                var orderList = await _orderRepository.GetAllOrdersWithDishesAsync();

                if (orderList == null || orderList.Count == 0)
                {

                    return NotFound();
                }

                var responseDto = _mapper.Map<List<OrderDto>>(orderList);

                return Ok(responseDto);
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
        public async Task<IActionResult> GetById(int ID)
        {
            try
            {
                var mesa = await _orderRepository.GetOrderWithDishesAsync(ID);

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
