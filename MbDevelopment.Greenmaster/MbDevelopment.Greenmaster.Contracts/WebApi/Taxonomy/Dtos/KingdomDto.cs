namespace MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;

public class KingdomDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}