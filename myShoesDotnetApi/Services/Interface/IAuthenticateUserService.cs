
using myShoesDotnetApi.Models;

namespace myShoesDotnetApi.Services
{
    public interface IAuthenticateUserService
    {
        Task<bool> RegisterUser(User user); 
        Task<bool> Login(User user);

    }
}

