using MbDevelopment.Greenmaster.Core;
using MbDevelopment.Greenmaster.Core.Botanical;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Seeders;

public static class BotanicalSeeders
{
    public static void SeedSpecies(this ModelBuilder modelBuilder)
    {
        Console.WriteLine("Seeding Species...");

        modelBuilder.Entity<Species>().HasData(
        [
            new Species
            {
                Id = 1,
                LatinName = "Ginkgo Biloba",
                Description =
                    "Een boom uit de familie Ginkgoaceae. " +
                    "De soort is oorspronkelijk afkomstig uit China; hij wordt gekweekt en is niet meer in het wild bekend.",
                CommonNames = new List<CommonName>()
            }
            
        ]);
    }

    public static void SeedGenera(this ModelBuilder modelBuilder)
    {
        Console.WriteLine("Seeding Genera...");
        modelBuilder.Entity<Genus>().HasData(
        [
            new Genus { Id = 1, LatinName = "Ginkgo", Description = "non-flowering seed plants" },
            new Genus { Id = 2, LatinName = "Linum" },
            new Genus { Id = 3, LatinName = "Strelitzia" }
        ]);
    }

    public static void SeedCommonNames(this ModelBuilder modelBuilder)
    {
        Console.WriteLine("Seeding CommonNames...");
        modelBuilder.Entity<CommonName>().HasData(
        [
            new CommonName()
            {
                Id = 1,
                Name = "ginkgo",
                UsedByLanguages = [LanguageIsoCodes.EN],
                SpeciesId = 1
            },
            new CommonName()
            {
                Id = 2,
                Name = "japanse notenboom",
                UsedByLanguages = [LanguageIsoCodes.NL],
                SpeciesId = 1
            }
        ]);
    }
}