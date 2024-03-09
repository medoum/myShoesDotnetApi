using System;
using AutoMapper;
using myShoesDotnetApi.Dtos;
using myShoesDotnetApi.Models.Enum;

namespace myShoesDotnetApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}

