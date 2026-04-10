using NeoGenesis.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace NeoGenesis.Infrastructure.Configurations;

public class MySqlDbContext : DbContext
{
    public DbSet<Dinosaur> Dinosaurs { get; set; }
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }
}

public class MySqlDbContextFactory : IDesignTimeDbContextFactory<MySqlDbContext>
{
    public MySqlDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MySqlDbContext>();

        optionsBuilder.UseMySql(
            "server=204.168.211.73;database=neogenesis;user=root;password=gWTeX0zTHgGQ6G1",
            new MySqlServerVersion(new Version(8, 0, 0)) // Mysql Version
        );

        return new MySqlDbContext(optionsBuilder.Options);
    }
}
