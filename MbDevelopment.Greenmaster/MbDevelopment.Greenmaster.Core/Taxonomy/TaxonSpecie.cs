namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public interface ISpecies : ITaxonomyItem
{
    public string Cultivar { get; set; }
}