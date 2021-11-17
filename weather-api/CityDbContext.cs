using Microsoft.EntityFrameworkCore;

public class CityDbContext : DbContext
{
    public CityDbContext(DbContextOptions<CityDbContext> options)
        : base(options)
    {
    }
    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=City.db");
    }

    public DbSet<City> Cities { get; set; } 
}