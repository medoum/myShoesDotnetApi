using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myShoesDotnetApi.Dtos;
using myShoesDotnetApi.Models;
using myShoesDotnetApi.Repository.Interface;
using myShoesDotnetApi.Services.Interface;

namespace myShoesDotnetApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;


        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
           
            _mapper = mapper;
            _userManager = userManager;
        }

        public Task<UserDto> DeleteUer(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public Task<UserDto> UpdateUer(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
