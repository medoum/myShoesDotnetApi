﻿using System;
using Microsoft.EntityFrameworkCore;
using myShoesDotnetApi.Data;
using myShoesDotnetApi.Models.Enum;
using myShoesDotnetApi.Repository.Interface;

namespace myShoesDotnetApi.Repository
{ 
	
        public class ProductRepository : IProductRepository
        {
            private readonly AppDbContext _dbContext;

            public ProductRepository(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task AddAsync(Product entity)
            {
                await _dbContext.Products.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }

            public async Task<IEnumerable<Product>> GetAllAsync()
            {
                return await _dbContext.Products
                    .Include(p => p.Category)
                    .ToListAsync();
            }

            public async Task<Product> GetByIdAsync(int id)
            {
                return await _dbContext.Products
                    .Include(product => product.Category)
                    .FirstOrDefaultAsync(product => product.Id == id);
            }

            public async Task RemoveAsync(Product entity)
            {
                _dbContext.Products.Remove(entity);
                await _dbContext.SaveChangesAsync();

            }

            public async Task<bool> SkuExistsAsync(string sku)
            {
                return await _dbContext.Products.AnyAsync(p => p.Sku == sku);
            }

            public async Task UpdateAsync(Product entity)
            {
                _dbContext.Products.Update(entity);
                await _dbContext.SaveChangesAsync();

            }
        }
    }


