namespace MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;

public class SpeciesDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Cultivar { get; set; }
    public string CommonName { get; set; }
    public string TrademarkName { get; set;}
    public string FullLatinName { get; set; }
    public string ImageUrl { get; set; }
    public BasicTaxonDto Genus { get; set; }
}