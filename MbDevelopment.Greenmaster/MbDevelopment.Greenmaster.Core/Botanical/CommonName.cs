using System.ComponentModel.DataAnnotations;

namespace MbDevelopment.Greenmaster.Core.Botanical;

public class CommonName
{
    [Key]
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string[] UsedByLanguages { get; set; } = {LanguageIsoCodes.English};
}