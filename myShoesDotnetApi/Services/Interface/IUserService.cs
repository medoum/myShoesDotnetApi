using myShoesDotnetApi.Dtos;

namespace myShoesDotnetApi.Services.Interface
{
    public interface IUserService 
    {
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
