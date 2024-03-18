using MbDevelopment.Greenmaster.Core.Taxonomy;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Seeders;

public static class TaxonomySeeders
{
    public static void SeedTaxonKingdoms(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxonKingdom>().HasData(new List<TaxonKingdom>()
        {
            new ()
            {
                Id = Guid.Parse("8925789d-2a37-4b86-89ba-657184ca4e33"),
                LatinName = "Animalia",
                Description = "The kingdom of animals.",
            },
            new ()
            {
                Id = Guid.Parse("0d68e396-d131-40c0-b89c-cc8ecd9b67dc"),
                LatinName = "Plantae",
                Description = "The kingdom of plants.",
            },
            new ()
            {
                Id = Guid.Parse("38d1cc00-9f59-472a-9f84-323e18ecc968"),
                LatinName = "Fungi",
                Description = "The kingdom of fungi.",
            },
            new ()
            {
                Id = Guid.Parse("045abec7-aa1f-42f9-b14a-a099ca597041"),
                LatinName = "Protista",
                Description = "The kingdom of protista.",
            }
        });
    }
}