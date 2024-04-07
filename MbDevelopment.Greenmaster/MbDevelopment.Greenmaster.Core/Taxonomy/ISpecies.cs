namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public interface ISpecies : ITaxonomyItem
{
    public string Cultivar { get; set; }
    public string FullLatinName { get; }
    public string CommonName { get; set; }
    public string TrademarkName { get; set; }
}