using Microsoft.EntityFrameworkCore;
using NeoGenesis.Entities;

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

            entity.Property(d => d.DinoName).IsRequired().HasMaxLength(100);
            entity.Property(d => d.DinoSpecies).IsRequired().HasMaxLength(100);
            entity.Property(d => d.Username).IsRequired().HasMaxLength(50);
            entity.Property(d => d.RegisterCode).IsRequired().HasMaxLength(150);

            entity.HasIndex(d => d.Username).IsUnique();
            entity.HasIndex(d => d.RegisterCode).IsUnique();
            
            entity.HasKey(d => d.Id);

            entity.Property(d => d.Address).HasColumnName("Address");
            entity.Property(d => d.Zone).HasColumnName("Zone");
            entity.Property(d => d.Sector).HasColumnName("Sector");
            entity.Property(d => d.Type).HasColumnName("Type");
            entity.Property(d => d.Age).HasColumnName("Age");
            entity.Property(d => d.Password).HasColumnName("Password");
            entity.Property(d => d.CreatedAt).HasColumnName("CreatedAt");
            entity.Property(d => d.UpdatedAt).HasColumnName("UpdatedAt");

            entity.HasIndex(d => d.Username).IsUnique();
            entity.HasIndex(d => d.RegisterCode).IsUnique();
        });
    }
}