using MbDevelopment.Greenmaster.Core.Taxonomy;
using Microsoft.EntityFrameworkCore;
using static MbDevelopment.Greenmaster.DataAccess.Seeders.TaxonomySeeders;

namespace MbDevelopment.Greenmaster.DataAccess;

public class BotanicalContext(DbContextOptions<BotanicalContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedTaxonomy(modelBuilder);
    }
    
    public DbSet<TaxonKingdom> TaxonKingdoms { get; set; } = null!;
    public DbSet<TaxonPhylum> TaxonPhyla { get; set; } = null!;
    public DbSet<TaxonClass> TaxonClasses { get; set; } = null!;
    public DbSet<TaxonOrder> TaxonOrders { get; set; } = null!;
    public DbSet<TaxonFamily> TaxonFamilies { get; set; } = null!;
    public DbSet<TaxonGenus> TaxonGenera { get; set; } = null!;
    public DbSet<TaxonSpecies> TaxonSpecies { get; set; } = null!;

    
}