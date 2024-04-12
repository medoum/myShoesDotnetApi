using AutoMapper;
using Microsoft.AspNetCore.Identity;
using myShoesDotnetApi.Models;

namespace myShoesDotnetApi.Profiles
{
    public class AuthUserProfile : Profile
    {
        public AuthUserProfile()
        {
            CreateMap<User, IdentityUser>().ReverseMap();

        }

    }
}
