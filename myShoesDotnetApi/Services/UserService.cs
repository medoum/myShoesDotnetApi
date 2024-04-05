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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;


        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;

            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
