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

            #region Dish
            CreateMap<Dish, DishCreateDto>().ReverseMap();
            CreateMap<Dish, DishUpdateDto>().ReverseMap();
            CreateMap<Dish, DishDto>()
             .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.DishIngredients.Select(di => di.Ingredient).ToList()));
            #endregion

            #region Tables
            CreateMap<Mesas, TablesCreateDto>().ReverseMap();
            CreateMap<Mesas, TablesUpdateDto>().ReverseMap();
            CreateMap<Mesas, TablesDto>().ReverseMap();
            #endregion

            #region Orders
            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<Order, OrderUpdateDto>().ReverseMap();
            CreateMap<Order, OrderDto>()
           .ForMember(dest => dest.Dishs, opt => opt.MapFrom(src => src.OrderDish.Select(od => od.Dish).ToList()));

            #endregion

        }
    }
}
