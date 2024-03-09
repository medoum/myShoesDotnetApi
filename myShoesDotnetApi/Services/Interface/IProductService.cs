using System;
using myShoesDotnetApi.Dtos;

namespace myShoesDotnetApi.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductDto> AddAsync(ProductDto productDto);
        Task UpdateAsync(ProductDto productDto);
        Task RemoveAsync(int id);
        Task<bool> SkuExistsAsync(string sku);
    }
}

