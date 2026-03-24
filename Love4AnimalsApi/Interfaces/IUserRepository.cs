using System;
using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Interfaces;

public interface IUserRepository
    {
        User? getUser(int id); 
        void addUser(User user); 
    }
