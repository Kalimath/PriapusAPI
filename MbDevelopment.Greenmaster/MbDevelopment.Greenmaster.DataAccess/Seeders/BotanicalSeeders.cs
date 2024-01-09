using MbDevelopment.Greenmaster.Core;
using MbDevelopment.Greenmaster.Core.Botanical;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Seeders;

public static class BotanicalSeeders
{
    public static void SeedSpecies(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Species>().HasData(new Species[]
        {
            new()
            {
                Id = 1,
                LatinName = "Ginkgo Biloba",
                Description =
                    "De Japanse notenboom, ginkgo, tempelboom of eendenpootboom is een boom uit de familie Ginkgoaceae. " +
                    "De soort is oorspronkelijk afkomstig uit China; hij wordt gekweekt en is niet meer in het wild bekend.",
                CommonNames =
                    new[]
                    {
                        new CommonName
                        {
                            Id = 1,
                            Name = "ginkgo",
                            UsedByLanguages = [LanguageIsoCodes.English]
                        },
                        new CommonName()
                            { Id = 2, Name = "japanse notenboom", UsedByLanguages = new[] { LanguageIsoCodes.Dutch } }
                    }
            }
        });
    }

    public static void SeedGenera(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genus>().HasData(new Genus[]
        {
            new() { Id = 1, LatinName = "Ginkgo", Description = "non-flowering seed plants", Species = new[] { 1 } },
            new() { Id = 2, LatinName = "Linum" },
            new() { Id = 3, LatinName = "Strelitzia" }
        });
    }
}