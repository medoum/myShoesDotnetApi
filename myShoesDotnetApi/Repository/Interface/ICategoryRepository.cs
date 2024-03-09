using System;
using myShoesDotnetApi.Models.Enum;

namespace myShoesDotnetApi.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category entity);
        Task UpdateAsync(Category entity);
        Task RemoveAsync(Category entity);

        Task<bool> CategoryExist(int id);
    }

}