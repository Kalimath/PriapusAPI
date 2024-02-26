using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.Core.Examples;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Tests.Helpers;

public class BotanicalDataFixture : IDisposable
{
    public BotanicalContext BotanicalContext { get; private set; }

    public BotanicalDataFixture()
    {
        var options = new DbContextOptionsBuilder<BotanicalContext>()
            .UseInMemoryDatabase("botanicalDatabase")
            .Options;

        BotanicalContext = new BotanicalContext(options);
        BotanicalContext.Genera.AddRange(GenusExamples.Ginkgo, GenusExamples.Hosta);
        BotanicalContext.SaveChanges();
        
    }

    public void Dispose()
    {
        BotanicalContext.Database.EnsureDeleted();
        BotanicalContext.Dispose();
    }
}