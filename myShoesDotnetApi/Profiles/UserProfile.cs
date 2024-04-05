using AutoMapper;
using myShoesDotnetApi.Dtos;
using myShoesDotnetApi.Models;

namespace myShoesDotnetApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}

