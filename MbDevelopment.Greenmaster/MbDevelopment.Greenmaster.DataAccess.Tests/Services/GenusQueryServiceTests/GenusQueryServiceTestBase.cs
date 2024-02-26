using MbDevelopment.Greenmaster.DataAccess.Services;
using MbDevelopment.Greenmaster.DataAccess.Tests.Helpers;

namespace MbDevelopment.Greenmaster.DataAccess.Tests.Services.GenusQueryServiceTests;

[Collection(nameof(BotanicalDataFixture))]
public abstract class GenusQueryServiceTestBase : IClassFixture<BotanicalDataFixture>
{
    protected readonly BotanicalDataFixture Fixture;
    protected readonly IGenusQueryService Sut;
    
    protected GenusQueryServiceTestBase(BotanicalDataFixture fixture)
    {
        Fixture = fixture;
        Sut = new GenusQueryService(Fixture.BotanicalContext);
    }
}