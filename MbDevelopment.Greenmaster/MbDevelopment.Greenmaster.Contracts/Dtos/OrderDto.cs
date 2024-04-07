namespace MbDevelopment.Greenmaster.Contracts.Dtos;

public class OrderDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ClassDto Class { get; set; }
}