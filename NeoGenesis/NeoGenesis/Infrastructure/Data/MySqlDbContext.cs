using Microsoft.EntityFrameworkCore;
using NeoGenesis.Shared.Entities;

namespace NeoGenesis.Infrastructure.Data;

public class MySqlDbContext : DbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }

    public DbSet<Dinosaur> Dinosaurs => Set<Dinosaur>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dinosaur>(entity =>
        {
            entity.HasKey(d => d.Id);

            entity.Property(d => d.Dino_name).IsRequired().HasMaxLength(100);
            entity.Property(d => d.Dino_especie).IsRequired().HasMaxLength(100);
            entity.Property(d => d.Sobre_nombre).IsRequired().HasMaxLength(50);
            entity.Property(d => d.Register_code).IsRequired().HasMaxLength(150);

            entity.HasIndex(d => d.Sobre_nombre).IsUnique();
            entity.HasIndex(d => d.Register_code).IsUnique();
        });
    }
}