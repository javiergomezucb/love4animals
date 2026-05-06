using Microsoft.EntityFrameworkCore;
using Love4AnimalsApi.Data;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    // Inyectamos el contexto que configuramos antes
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    // Usamos AsNoTracking para consultas de solo lectura (mejora el rendimiento)
    public async Task<IEnumerable<User>> GetUsersAsync() 
        => await _context.Users.AsNoTracking().ToListAsync();

    public async Task<User?> GetUserAsync(int id) 
        => await _context.Users.FindAsync(id);

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync(); // Guarda físicamente en Podman[cite: 3]
    }

    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await GetUserAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}