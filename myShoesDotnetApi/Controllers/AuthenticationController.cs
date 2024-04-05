using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myShoesDotnetApi.Dtos;
using myShoesDotnetApi.Handlers;
using myShoesDotnetApi.Models;
using myShoesDotnetApi.Models.Enum;
using myShoesDotnetApi.Services.Interface;
using System.Security;

namespace myShoesDotnetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
     /*   private readonly IUserService _userService;*/
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthenticationController
            (
            /*IUserService userService,*/
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            /*_userService = userService;*/
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateUser([FromBody] UserDto UserDto, string role)   
        {
            if (UserDto == null || string.IsNullOrWhiteSpace(role))
            {
                return BadRequest("Invalid request");
            }
            var userExist = await _userManager.FindByEmailAsync(UserDto.Email);
            if(userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error" , Message = "User Already Exist"});
            }

            if (!await _roleManager.RoleExistsAsync(role))
            {
                return NotFound(new Response { Status = "Error", Message = "Invalid role specified" });
            }
            var user = new IdentityUser
            {
                Email = UserDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = UserDto.UserName,
            };

            var result = await _userManager.CreateAsync(user, UserDto.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to create user check all the caractere" });

            }

            await _userManager.AddToRoleAsync(user, role);

            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = "User Created Successfully" });
        }
    }
}
