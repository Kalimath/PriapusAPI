using MbDevelopment.Greenmaster.Core.Taxonomy;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Seeders;

public static class TaxonomySeeders
{

    public static void SeedTaxonomy(ModelBuilder modelBuilder)
    {
        SeedTaxonKingdoms(modelBuilder);
        SeedTaxonPhyla(modelBuilder);
        SeedTaxonClasses(modelBuilder);
        SeedTaxonOrders(modelBuilder);
    }
    
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
            }
        });
    }
    
    public static void SeedTaxonPhyla(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxonPhylum>().HasData(new List<TaxonPhylum>
        {
            new ()
            {
                Id = 1,
                LatinName = "Ginkgophyta",
                Description = "Ginkgo-like plant",
                KingdomId = 2
            },
            new ()
            {
                Id = 2,
                LatinName = "Pinophyta",
                Description = "Conifers",
                KingdomId = 2
            },
            new ()
            {
                Id = 3,
                LatinName = "Magnoliophyta",
                Description = "Flowering plants, angiosperms",
                KingdomId = 2
            },
            new ()
            {
                Id = 4,
                LatinName = "Lycopodiophyta",
                Description = "Clubmosses, spikemosses",
                KingdomId = 2
            },
            new ()
            {
                Id = 5,
                LatinName = "Arthropods",
                Description = "Animals with exoskeleton",
                KingdomId = 1
            },
            new ()
            {
                Id = 6,
                LatinName = "Chordata",
                Description = " Deuterostomic animals",
                KingdomId = 1
            }
        });
    }

    public static void SeedTaxonClasses(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxonClass>().HasData(new List<TaxonClass>()
        {
            new()
            {
                Id = 1,
                LatinName = "mammalia",
                Description =
                    "characterized by the presence of milk-producing mammary glands for feeding their young, " +
                    "a neocortex region of the brain, fur or hair, and three middle ear bones",
                PhylumId = 5
            },
            new()
            {
                Id = 2,
                LatinName = "Reptilia",
                Description =
                    "group of tetrapods with an ectothermic ('cold-blooded') metabolism and amniotic development",
                PhylumId = 5
            },
            new()
            {
                Id = 3,
                LatinName = "Ginkgoopsida",
                Description = "Flowering plants, angiosperms",
                PhylumId = 1
            },
            new()
            {
                Id = 4,
                LatinName = "Liliopsida",
                Description = "Lily flowering plants",
                PhylumId = 3
            }
        });
    }

    public static void SeedTaxonOrders(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxonOrder>().HasData(new List<TaxonOrder>()
        {
            new()
            {
                Id = 1,
                LatinName = "Aranae",
                Description = "Herbs with watery, milky and acrid sap",
                ClassId = 4
            },
            new()
            {
                Id = 2,
                LatinName = "Ginkgoales",
                Description = "containing only one extant species: Ginkgo biloba, the ginkgo tree",
                ClassId = 3
            }
        });
    }
}