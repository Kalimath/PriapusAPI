namespace MbDevelopment.Greenmaster.Contracts.Dtos;

public class ClassDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PhylumDto Phylum { get; set; }
}