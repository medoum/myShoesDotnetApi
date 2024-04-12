using AutoMapper;
using Microsoft.AspNetCore.Identity;
using myShoesDotnetApi.Dtos;
using myShoesDotnetApi.Models;
using System.Threading.Tasks;

namespace myShoesDotnetApi.Services
{
    public class AuthenticateUserService : IAuthenticateUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AuthenticateUserService(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

     

        public async Task<bool> Login(User user)
        {
            var loginUser = await _userManager.FindByEmailAsync(user.Email);
            if (loginUser is null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(loginUser, user.Password);
        }

        public async Task<bool> RegisterUser(User user) // Keep User for registration (assuming more details)
        {
            var identityUser = _mapper.Map<IdentityUser>(user); // Map to IdentityUser

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded; // Return true/false directly
        }
    }
}
