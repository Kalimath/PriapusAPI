using System.ComponentModel.DataAnnotations;

namespace MbDevelopment.Greenmaster.BotanicalWebService;

public class Species : ITaxonIdentifier
{
    [Key]
    public int Id { get; set; }
    public string LatinName { get; set; }
    public string? Description { get; set; }
    public CommonName[]? CommonNames { get; set; }
}