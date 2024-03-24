using MbDevelopment.Greenmaster.Core.Taxonomy;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Seeders;

public static class TaxonomySeeders
{
    public static void SeedTaxonKingdoms(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxonKingdom>().HasData(new List<TaxonKingdom>
        {
            new ()
            {
                Id = 1,
                LatinName = "Animalia",
                Description = "The kingdom of animals.",
            },
            new ()
            {
                Id = 2,
                LatinName = "Plantae",
                Description = "The kingdom of plants.",
            },
            new ()
            {
                Id = 3,
                LatinName = "Fungi",
                Description = "The kingdom of fungi.",
            },
            new ()
            {
                Id = 4,
                LatinName = "Protista",
                Description = "The kingdom of protista.",
            }
        });
    }
}