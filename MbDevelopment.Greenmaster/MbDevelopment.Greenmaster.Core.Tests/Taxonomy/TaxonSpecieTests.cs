using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.Core.Tests.Taxonomy;

public class TaxonSpecieTests
{
    [Fact]
    public void ShouldReturn_CorrectFullLatinName_WithEmptyCultivar()
    {
        var specie = new TaxonSpecies()
        {
            Genus = new TaxonGenus()
            {
                LatinName = "genus"
            },
            LatinName = "species",
            Cultivar = string.Empty
        };
        
        Assert.Equal("Genus Species", specie.FullLatinName);
    }
    
    [Fact]
    public void ShouldReturn_CorrectFullLatinName_WithCultivar()
    {
        var specie = new TaxonSpecies()
        {
            Genus = new TaxonGenus()
            {
                LatinName = "genus"
            },
            LatinName = "species",
            Cultivar = "some cultivar"
        };
        
        Assert.Equal("Genus Species \'Some Cultivar\'", specie.FullLatinName);
    }
}