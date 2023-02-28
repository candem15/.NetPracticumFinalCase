using AutoMapper;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Dtos.User;
using PracticumFinalCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<ShoppingList, ShoppingListDto>()
                .ForMember(dest => dest.OwnerUserName, opt => opt.MapFrom(src => src.Owner.Name))
                .ReverseMap();
        }
    }
}
