using System;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Love4AnimalsApi.Repositories;

public class UserRepository : IUserRepository
{
    private static List<User> _users = new List<User>();

    public UserRepository()
    {
    if (_users.Count == 0)
        {
        _users.Add(new User(1, "Name", "test@gmail.com"));
        }
    }
    public User getUser(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
    public void addUser(User user)
    {
     _users.Add(user);
    }
}

