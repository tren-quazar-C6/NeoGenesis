using NeoGenesis.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace NeoGenesis.Infrastructure.Configurations;

public class MySqlDbContext : DbContext
{
    public DbSet<Dinosaur> Dinosaurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(
        "server=;database=db_robinson_andres_cortes;user=root;password=",
        ServerVersion.AutoDetect("server=;database=db_robinson_andres_cortes;user=root;password=")
    );
}

