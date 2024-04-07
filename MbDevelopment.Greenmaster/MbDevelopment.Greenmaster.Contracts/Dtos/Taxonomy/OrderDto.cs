namespace MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;

public class OrderDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public BasicTaxonDto Class { get; set; }
}