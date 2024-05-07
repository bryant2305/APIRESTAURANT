using ApiRestaurant.Core.Application.Interfaces.Repositories;
using ApiRestaurant.Core.Application.Interfaces.Services;
using ApiRestaurant.Core.Application.ViewModels.Dish;
using ApiRestaurant.Core.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.Services
{
    public class DishService : GenericService<DishViewModel , SaveDishViewModel , Dish> , IDishService
    {
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;
        public DishService(IDishRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _dishRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<SaveDishViewModel>> GetAllViewModelWhitInclude()
        {
            var PlatosWhitInclude = await _dishRepository.GetAllWhitIncludes(new List<string> { "Ingredients" });
            return _mapper.Map<List<SaveDishViewModel>>(PlatosWhitInclude);
        }
       
    }
}
