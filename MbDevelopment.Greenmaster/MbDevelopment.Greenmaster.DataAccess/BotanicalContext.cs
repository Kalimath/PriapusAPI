using MbDevelopment.Greenmaster.Core.Taxonomy;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess;

public class BotanicalContext(DbContextOptions<BotanicalContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedTaxonKingdoms(modelBuilder);
    }
    
    public DbSet<TaxonKingdom> TaxonKingdoms { get; set; } = null!;
    // public DbSet<TaxonPhylum> TaxonPhyla { get; set; } = null!;
    // public DbSet<TaxonClass> TaxonClasses { get; set; } = null!;
    // public DbSet<TaxonOrder> TaxonOrders { get; set; } = null!;
    // public DbSet<TaxonFamily> TaxonFamilies { get; set; } = null!;
    // public DbSet<TaxonGenus> TaxonGenera { get; set; } = null!;
    // public DbSet<TaxonSpecies> TaxonSpecies { get; set; } = null!;

    private static void SeedTaxonKingdoms(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxonKingdom>().HasData(new List<TaxonKingdom>()
        {
            new ()
            {
                Id = Guid.NewGuid(),
                LatinName = "Animalia"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                LatinName = "Plantae"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                LatinName = "Fungi"
            },
            new ()
            {
                Id = Guid.NewGuid(),
                LatinName = "Protista"
            }
        });
    }
}