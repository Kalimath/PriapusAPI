namespace MbDevelopment.Greenmaster.BotanicalWebService;

public class Genus : ITaxonIdentifier
{
    public int Id { get; set; }
    public string LatinName { get; set; }
    public string? Description { get; set; }
    public ICollection<int> Species { get; set; } = Array.Empty<int>();
}