using myShoesDotnetApi.Dtos;

namespace myShoesDotnetApi.Services.Interface
{
    public interface IUserService 
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task<UserDto> GetUserById(int userId);
        Task<UserDto> UpdateUer(UserDto userDto);
        Task<UserDto> DeleteUer(int UserId);



    }
}
