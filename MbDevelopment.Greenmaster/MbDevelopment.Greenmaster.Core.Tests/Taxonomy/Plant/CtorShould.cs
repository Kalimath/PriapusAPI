namespace MbDevelopment.Greenmaster.Core.Tests.Taxonomy.Plant;

public class CtorShould
{
    private const string SomeLatinName = "some latinName";
    private const string SomeDescription = "some description";
    private static readonly Guid SomeId = Guid.NewGuid();

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

    private class TestPlant : Core.Taxonomy.Plant
    {
        public TestPlant(Guid id,string latinName, string description) : base(id, latinName, description)
        {
        }
    }
}