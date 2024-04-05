using myShoesDotnetApi.Models;

namespace myShoesDotnetApi.Repository.Interface
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
    }
}
