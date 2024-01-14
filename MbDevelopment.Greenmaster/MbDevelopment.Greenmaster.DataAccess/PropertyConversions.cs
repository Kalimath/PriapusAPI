using MbDevelopment.Greenmaster.Core;
using MbDevelopment.Greenmaster.Core.Botanical;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess;

public static class PropertyConversions
{
    public static void CommonNamesConverters(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CommonName>()
         .Property(e => e.UsedByLanguages)
         .HasConversion(
             v => string.Join(',', v.Select(x => x.ToString())),
             v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<LanguageIsoCodes>).ToArray());
    }
}