namespace MbDevelopment.Greenmaster.Core.Botanical;

public class Genus : ITaxonIdentifier
{
    public required int Id { get; set; }
    public required string LatinName { get; set; }
    public string? Description { get; set; }
    public ICollection<int> Species { get; set; } = Array.Empty<int>();
}