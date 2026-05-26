using System;

namespace Love4AnimalsApi.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }
    public User() { }
    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
        PasswordHash = string.Empty;
    }
}
