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
                .ForMember(dest => dest.OwnerUserName, opt => opt.MapFrom(src => src.User.Name))
                .ReverseMap();
            CreateMap<ShoppingList, UpdateShoppingListDto>()
               .ForMember(dest => dest.ProductsId, opt => opt.MapFrom(src => src.Products.Select(x => x.Id).ToList()))
               .ReverseMap();
            CreateMap<ShoppingList, ShoppingListEventDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.OwnerUserName, opt => opt.MapFrom(src => src.User.Name))
                .ReverseMap();
        }
    }
}
