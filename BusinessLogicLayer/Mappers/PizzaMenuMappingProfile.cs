using AutoMapper;
using DataAccessLayer.Entities;
using eCommerce.BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mappers
{
    public class PizzaMenuMappingProfile : Profile
    {
        public PizzaMenuMappingProfile()
        {
            // Pizza mappings
            CreateMap<PizzaSize, PizzaSizeResponse>().ReverseMap();
            CreateMap<PizzaSizeAddRequest, PizzaSize>();
            CreateMap<PizzaSizeUpdateRequest, PizzaSize>();

            // Topping mappings
            CreateMap<Topping, ToppingResponse>().ReverseMap();
            CreateMap<ToppingAddRequest, Topping>();
            CreateMap<ToppingUpdateRequest, Topping>();
        }
    }
}
