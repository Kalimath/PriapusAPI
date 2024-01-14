using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.DataAccess.Seeders;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess;

public class BotanicalContext(DbContextOptions<BotanicalContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder options){}
    
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