namespace MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;

public class BasicTaxonDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ParentTaxonType { get; set; }
    public string ParentTaxonId { get; set; }
}