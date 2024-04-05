﻿using Microsoft.EntityFrameworkCore;
using myShoesDotnetApi.Data;
using myShoesDotnetApi.Models;
using myShoesDotnetApi.Repository.Interface;

namespace myShoesDotnetApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
           return await _context.Users.ToListAsync();
        }
    }
}
