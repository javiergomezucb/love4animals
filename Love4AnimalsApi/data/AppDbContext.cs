using Microsoft.EntityFrameworkCore;
using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Tablas de la base de datos
    public DbSet<User> Users => Set<User>();
    public DbSet<Campaign> Campaigns => Set<Campaign>();
    public DbSet<Donation> Donations => Set<Donation>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Configuración de precisión (Estándar UCB para Cochabamba)
        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.Property(c => c.GoalAmount).HasPrecision(18, 2);
            entity.Property(c => c.AmountCollected).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.Property(d => d.Amount).HasPrecision(18, 2);
        });
    }
}
