using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.Core.Examples;
using MbDevelopment.Greenmaster.DataAccess.Services;
using MbDevelopment.Greenmaster.DataAccess.Tests.Helpers;

namespace MbDevelopment.Greenmaster.DataAccess.Tests.Services.GeneraQueryServiceTests;

[Collection(nameof(BotanicalDataFixture))]
public class GetByIdShould : IGetByIdShould
{
    private readonly IGenusQueryService _sut;


    public GetByIdShould(BotanicalDataFixture fixture)
    {
        _sut = new GenusQueryService(fixture.BotanicalContext);
        
    }

    [Fact]
    public async Task ReturnExpected_WhenFound()
    {
        var result = await _sut.GetById(GenusExamples.Ginkgo.Id);
        
        Assert.NotNull(result);
        Assert.Equivalent(GenusExamples.Ginkgo, result);
    }
    
    [Fact]
    public async Task ReturnNull_WhenNotFound()
    {
        var genera = new List<Genus> { GenusExamples.Ginkgo, GenusExamples.Hosta };
        var invalidId = genera.Max(genus => genus.Id) + 1;
        
        var result = await _sut.GetById(invalidId);
        
        Assert.Null(result);
    }
}