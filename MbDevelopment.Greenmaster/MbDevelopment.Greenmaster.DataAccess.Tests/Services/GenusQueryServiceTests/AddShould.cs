using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.DataAccess.Tests.Helpers;
using static MbDevelopment.Greenmaster.Core.Examples.GenusExamples;

namespace MbDevelopment.Greenmaster.DataAccess.Tests.Services.GenusQueryServiceTests;

public class AddShould(BotanicalDataFixture fixture) : GenusQueryServiceTestBase(fixture)
{
    [Fact]
    public async Task ThrowArgumentNullException_WhenGenusNull()
    {
        Task Act() => Sut.Add(null!);
        
        await Assert.ThrowsAsync<ArgumentNullException>(Act);
    }  
    
    [Fact]
    public async Task ThrowArgumentOutOfRangeException_WhenGenusIdZero()
    {
        Task Act() => Sut.Add(new Genus
        {
            Id = 0,
            LatinName = "Test",
            Description = "Test Description"
        });
        
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(Act);
    }    
    
    [Fact]
    public async Task ThrowArgumentException_WhenGenusLatinNameNullOrEmpty()
    {
        Task Act() => Sut.Add(new Genus
        {
            Id = UnusedId,
            LatinName = null!,
            Description = "Test Description"
        });
        
        await Assert.ThrowsAsync<ArgumentNullException>(Act);
    }  
    
    [Fact]
    public async Task Persist_WhenValid()
    {
        var newGenus = new Genus
        {
            Id = UnusedId,
            LatinName = "New Genus",
            Description = "New Genus description"
        };
        
        await Sut.Add(newGenus);
        
        var result = Fixture.BotanicalContext.Genera
            .FirstOrDefault(genus => genus.LatinName == newGenus.LatinName);
        
        Assert.NotNull(result);
        Assert.Equal(newGenus.Id, result.Id);
        Assert.Equal(newGenus.LatinName, result.LatinName);
        Assert.Equal(newGenus.Description, result.Description);
    }   
}