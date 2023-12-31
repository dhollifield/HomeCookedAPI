﻿using HomeCooked.Models;

namespace HomeCooked.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
    }
}