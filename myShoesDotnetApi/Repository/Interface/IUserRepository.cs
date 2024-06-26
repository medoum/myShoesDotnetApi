﻿using myShoesDotnetApi.Models;

namespace myShoesDotnetApi.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
