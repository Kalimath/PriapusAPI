namespace MbDevelopment.Greenmaster.Core.Botanical;

public class Genus : ITaxonIdentifier
{
    public required int Id { get; set; }
    public required string LatinName { get; set; }
    public string? Description { get; set; }
    
    public ICollection<Species> Species { get; set; } = new List<Species>(); // Collection navigation containing dependents
}