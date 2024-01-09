using System.ComponentModel.DataAnnotations;

namespace MbDevelopment.Greenmaster.Core.Botanical;

public class Species : ITaxonIdentifier
{
    [Key]
    public required int Id { get; set; }
    public required string LatinName { get; set; }
    public string? Description { get; set; }
    public CommonName[]? CommonNames { get; set; }
}