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
            //Product mappings
            CreateMap<Product, ProductDto>().ReverseMap();

            //User mappings
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();

            //ShoppingList mappings
            CreateMap<ShoppingList, ShoppingListDto>()
                .ForMember(dest => dest.OwnerUserName, opt => opt.MapFrom(src => src.Owner.Name))
                .ReverseMap();
            CreateMap<ShoppingList, UpdateShoppingListDto>()
               .ForMember(dest => dest.ProductsId, opt => opt.MapFrom(src => src.Products.Select(x => x.Id).ToList()))
               .ReverseMap();

        }
    }
}
