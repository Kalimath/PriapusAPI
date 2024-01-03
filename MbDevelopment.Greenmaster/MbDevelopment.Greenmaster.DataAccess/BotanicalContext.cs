using MbDevelopment.Greenmaster.BotanicalWebService;
using MbDevelopment.Greenmaster.DataAccess.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MbDevelopment.Greenmaster.DataAccess;

public class BotanicalContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public BotanicalContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("TestDb");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedSpecies();
        modelBuilder.SeedGenera();
    }
    
    public DbSet<Species> Species { get; set; } = null!;
    public DbSet<Genus> Genera { get; set; } = null!;
}