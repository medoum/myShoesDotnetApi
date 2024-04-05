using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myShoesDotnetApi.Dtos;
using myShoesDotnetApi.Services.Interface;

namespace myShoesDotnetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;

        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()

        {
            var userDtos = await _userService.GetUsers();

            return Ok(userDtos);
        }

    }
}
