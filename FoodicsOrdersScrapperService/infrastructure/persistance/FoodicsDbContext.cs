using FoodicsOrdersScrapperService.domain.entities;
using Microsoft.EntityFrameworkCore;

namespace FoodicsOrdersScrapperService.infrastructure.persistance;

public class FoodicsDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    private readonly IConfiguration _configuration;
    public FoodicsDbContext(IConfiguration configuration) : base()
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("Database");
        optionsBuilder.UseSqlServer(connectionString);
    }
}
