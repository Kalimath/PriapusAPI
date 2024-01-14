using MbDevelopment.Greenmaster.Core.Botanical;
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
        options.UseInMemoryDatabase("testDb");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //conversions
        modelBuilder.CommonNamesConverters();
        //modelBuilder.Entity<Cultivar>().HasBaseType(typeof(ITaxonIdentifier));
        
        //seed data
        modelBuilder.SeedSpecies();
        modelBuilder.SeedGenera();
    }
    
    public DbSet<Species> Species { get; set; } = null!;
    public DbSet<Genus> Genera { get; set; } = null!;
    public DbSet<CommonName> CommonNames { get; set; } = null!;
}