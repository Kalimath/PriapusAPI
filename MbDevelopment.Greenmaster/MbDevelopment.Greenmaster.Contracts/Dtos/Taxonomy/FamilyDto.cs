namespace MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;

public class FamilyDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public BasicTaxonDto Order { get; set; }

}