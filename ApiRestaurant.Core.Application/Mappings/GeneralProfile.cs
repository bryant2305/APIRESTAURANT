using ApiRestaurant.Core.Application.ViewModels.Ingredients;
using ApiRestaurant.Core.Application.ViewModels.Tables;
using ApiRestaurant.Core.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {

        public GeneralProfile() {

            CreateMap<Mesas, MesasViewModel>()
                   .ReverseMap()
                       .ForMember(x => x.Created, opt => opt.Ignore())
                       .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                       .ForMember(x => x.LastModifyBy, opt => opt.Ignore())
                       .ForMember(x => x.LastModify, opt => opt.Ignore());

            CreateMap<Mesas, SaveMesasViewModel>()
                //.ForMember(x => x.Ordenes, opt=> opt.Ignore())
                .ReverseMap()
                    .ForMember(x => x.Created, opt => opt.Ignore())
                    .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                    .ForMember(x => x.LastModify, opt => opt.Ignore())
                    .ForMember(x => x.LastModifyBy, opt => opt.Ignore());

            CreateMap<Ingredient, IngredientViewModel>()
                   .ReverseMap()
                       .ForMember(x => x.Created, opt => opt.Ignore())
                       .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                       .ForMember(x => x.LastModifyBy, opt => opt.Ignore())
                       .ForMember(x => x.LastModify, opt => opt.Ignore());

            CreateMap<Ingredient, SaveIngredientViewModel>()
                .ReverseMap()
                    .ForMember(x => x.Created, opt => opt.Ignore())
                    .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                    .ForMember(x => x.LastModify, opt => opt.Ignore())
                    .ForMember(x => x.LastModifyBy, opt => opt.Ignore());


        }
    }
}
