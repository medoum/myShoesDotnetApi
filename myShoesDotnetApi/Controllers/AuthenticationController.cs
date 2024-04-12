using Microsoft.AspNetCore.Mvc;
using myShoesDotnetApi.Dtos;
using myShoesDotnetApi.Models;
using myShoesDotnetApi.Services;

namespace myShoesDotnetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticateUserService _authicateUserService;

        public AuthenticationController(IAuthenticateUserService authicateUserService)
        {
            _authicateUserService = authicateUserService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            var registeredUser = await _authicateUserService.RegisterUser(user);
            if (registeredUser != null)
            {
                return Ok(registeredUser); // Return the newly registered user object
            }
            return BadRequest("Registration failed. Please check your information.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(User userLoginDto) // Use a specific LoginDto
        {
            var loggedInUser = await _authicateUserService.Login(userLoginDto);
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (loggedInUser != null)
            {
                return Ok(loggedInUser); // Return a LoginResponseDto containing relevant user data and token
            }

            return BadRequest("Invalid username or password.");
        }
    }
}
