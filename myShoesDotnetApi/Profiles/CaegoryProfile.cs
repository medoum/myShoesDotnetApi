using System;
using AutoMapper;
using myShoesDotnetApi.Dtos;
using myShoesDotnetApi.Models.Enum;

namespace myShoesDotnetApi.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}

