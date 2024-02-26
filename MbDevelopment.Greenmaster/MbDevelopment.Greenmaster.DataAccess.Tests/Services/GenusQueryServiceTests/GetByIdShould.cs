using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.Core.Examples;
using MbDevelopment.Greenmaster.DataAccess.Tests.Helpers;

namespace MbDevelopment.Greenmaster.DataAccess.Tests.Services.GenusQueryServiceTests;

public class GetByIdShould : GenusQueryServiceTestBase, IGetByIdShould
{
    public GetByIdShould(BotanicalDataFixture fixture) : base(fixture)
    {
    }
    //TODO: test for behavior when id is invalid

    [Fact]
    public async Task ReturnExpected_WhenFound()
    {
        var result = await Sut.GetById(GenusExamples.Ginkgo.Id);
        
        Assert.NotNull(result);
        Assert.Equivalent(GenusExamples.Ginkgo, result);
    }
    
    [Fact]
    public async Task ReturnNull_WhenNotFound()
    {
        var genera = new List<Genus> { GenusExamples.Ginkgo, GenusExamples.Hosta };
        var invalidId = genera.Max(genus => genus.Id) + 1;
        
        var result = await Sut.GetById(invalidId);
        
        Assert.Null(result);
    }
}