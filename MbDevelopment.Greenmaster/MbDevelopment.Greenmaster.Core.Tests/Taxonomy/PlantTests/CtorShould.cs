using MbDevelopment.Greenmaster.Core.Taxonomy;
using NSubstitute;

namespace MbDevelopment.Greenmaster.Core.Tests.Taxonomy.PlantTests;

public class CtorShould
{
    private const string SomeLatinName = "some species latinName";
    private const string SomeDescription = "some plant description";
    private static readonly int SomeId = 5586;
    private readonly ISpecies _someSpecie;

    public CtorShould()
    {
        _someSpecie = Substitute.For<ISpecies>();
        _someSpecie.LatinName.Returns(SomeLatinName);
    }

    #region WithId

    [Fact]
    public void ThrowArgumentNullExceptionWhenLatinNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new Plant(SomeId,null!, SomeDescription));
    }

    [Fact]
    public void SetLatinName_ToProvided()
    {
        var plant = new Plant(SomeId, _someSpecie, SomeDescription);
        
        Assert.Equal(SomeLatinName, plant.Specie.LatinName);
    }
    
    [Fact]
    public void SetDescriptionToEmpty_WhenNull()
    {
        var result = new Plant(SomeId, _someSpecie, null!);
       
        Assert.Equal(string.Empty, result.Description);
    }

    [Fact]
    public void SetDescription_ToProvided()
    {
        var result = new Plant(SomeId, _someSpecie, SomeDescription);
        
        Assert.Equal(SomeDescription, result.Description);
    }

    [Fact]
    public void ThrowArgumentException_WhenIdInvalid()
    {
        Assert.Throws<ArgumentException>(() => new Plant(-1, _someSpecie, SomeDescription));
    }

    [Fact]
    public void SetId_ToProvided()
    {
        var result = new Plant(SomeId, _someSpecie, SomeDescription);
        
        Assert.Equal(SomeId, result.Id);
    }

    #endregion
}