namespace MbDevelopment.Greenmaster.Contracts.Dtos;

public class PhylumDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public KingdomDto Kingdom { get; set; }
}