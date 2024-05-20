using ApiRestaurant.Core.Application.DTOS.Dish;
using ApiRestaurant.Core.Application.DTOS.Ingredients;
using ApiRestaurant.Core.Application.DTOS.Orders;
using ApiRestaurant.Core.Application.DTOS.Tables;
using ApiRestaurant.Core.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {

        public GeneralProfile() {

          
            #region ingredients
            CreateMap<Ingredient, IngredientCreateDto>().ReverseMap();
            CreateMap<Ingredient, IngredientUpdateDto>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            #endregion
            CreateMap<Dish, DishDto>()
                      .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients.Select(di => new IngredientDto
                      {
                          ID = di.IngredientId , 
                          Name = di.Ingredient.Name
                      }).ToList()));

            CreateMap<DishCreateDto, Dish>()
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src =>
                    src.IngredientIds.Select(id => new DishIngredients {
                        IngredientId = id , }).ToList()));

            #region Tables
            CreateMap<Mesas, TablesCreateDto>().ReverseMap();
            CreateMap<Mesas, TablesUpdateDto>().ReverseMap();
            CreateMap<Mesas, TablesDto>().ReverseMap();
            #endregion

            #region Orders
            CreateMap<OrderCreateDto, Order>().ForMember(dest => dest.OrderDishes, opt => opt.MapFrom(src =>
                    src.DishIds.Select(id => new OrderDish {
                        DishID = id
                    }).ToList()));

            CreateMap<Order, OrderUpdateDto>().ReverseMap();
            CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src =>
                src.OrderDishes.Select(od => new DishDto
                {
                    ID = od.DishID,
                    Name = od.Dish.Name,
                    Category = od.Dish.Category,
                    Ingredients = (List<IngredientDto>)od.Dish.Ingredients
                }).ToList()));;
        }

        #endregion

    }
    }

