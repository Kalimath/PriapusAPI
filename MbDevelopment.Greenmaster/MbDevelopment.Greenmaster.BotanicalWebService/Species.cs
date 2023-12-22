using System.ComponentModel.DataAnnotations;

namespace MbDevelopment.Greenmaster.BotanicalWebService;

public class Species
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public CommonName[] CommonNames { get; set; }
}

public class CommonName
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] UsedByLanguages { get; set; } = new []{LanguageIsoCodes.English};
}