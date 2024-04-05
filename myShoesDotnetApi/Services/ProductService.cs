﻿using System;
using AutoMapper;
using myShoesDotnetApi.Dtos;
using myShoesDotnetApi.Models.Enum;
using myShoesDotnetApi.Repository.Interface;
using myShoesDotnetApi.Services.Interface;

namespace myShoesDotnetApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            await _productRepository.AddAsync(product);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productDtos;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task RemoveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            await _productRepository.RemoveAsync(product);
        }

        public Task<bool> SkuExistsAsync(string sku)
        {
            return _productRepository.SkuExistsAsync(sku);
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productDto.Id);

            _mapper.Map(productDto, product);

            await _productRepository.UpdateAsync(product);
        }
    }
}

