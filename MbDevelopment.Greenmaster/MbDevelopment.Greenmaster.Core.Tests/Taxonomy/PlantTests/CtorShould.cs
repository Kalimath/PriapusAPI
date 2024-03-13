using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.Core.Tests.Taxonomy.PlantTests;

public class CtorShould
{
    private const string SomeLatinName = "some latinName";
    private const string SomeDescription = "some description";
    private static readonly Guid SomeId = Guid.NewGuid();

    #region WithId

    [Fact]
    public void ThrowArgumentNullExceptionWhenLatinNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new TestPlant(SomeId,null!, SomeDescription));
    }

    [Fact]
    public void SetLatinName_ToProvided()
    {
        var plant = new TestPlant(SomeId, SomeLatinName, SomeDescription);
        
        Assert.Equal(SomeLatinName, plant.LatinName);
    }
    
    [Fact]
    public void SetDescriptionToEmpty_WhenNull()
    {
        var result = new TestPlant(SomeId, SomeLatinName, null!);
       
        Assert.Equal(string.Empty, result.Description);
    }

    [Fact]
    public void SetDescription_ToProvided()
    {
        var result = new TestPlant(SomeId, SomeLatinName, SomeDescription);
        
        Assert.Equal(SomeDescription, result.Description);
    }

    [Fact]
    public void ThrowArgumentException_WhenIdEmpty()
    {
        Assert.Throws<ArgumentException>(() => new TestPlant(Guid.Empty, SomeLatinName, SomeDescription));
    }

    [Fact]
    public void SetId_ToProvided()
    {
        var result = new TestPlant(SomeId, SomeLatinName, SomeDescription);
        
        Assert.Equal(SomeId, result.Id);
    }

    #endregion
    
    #region WithoutId

    [Fact]
    public void ThrowArgumentNullExceptionWhenLatinNameIsNull_AndCtorWithoutId()
    {
        Assert.Throws<ArgumentNullException>(() => new TestPlant(null!, SomeDescription));
    }

    [Fact]
    public void SetLatinName_ToProvided_AndCtorWithoutId()
    {
        var plant = new TestPlant(SomeLatinName, SomeDescription);
        
        Assert.Equal(SomeLatinName, plant.LatinName);
    }
    
    [Fact]
    public void SetDescriptionToEmpty_WhenNull_AndCtorWithoutId()
    {
        var result = new TestPlant(SomeLatinName, null!);
       
        Assert.Equal(string.Empty, result.Description);
    }

    [Fact]
    public void SetDescription_ToProvided_AndCtorWithoutId()
    {
        var result = new TestPlant(SomeLatinName, SomeDescription);
        
        Assert.Equal(SomeDescription, result.Description);
    }

    [Fact]
    public void GenerateId_WhenCtorWithoutId()
    {
        var result = new TestPlant(SomeId, SomeLatinName, SomeDescription);
        
        Assert.Equal(SomeId, result.Id);
    }

    #endregion

    private class TestPlant : Plant
    {
        public TestPlant(Guid id,string latinName, string description) : base(id, latinName, description)
        {
        }

        public TestPlant(string latinName, string description = "") : base(latinName, description)
        {
        }
    }
}