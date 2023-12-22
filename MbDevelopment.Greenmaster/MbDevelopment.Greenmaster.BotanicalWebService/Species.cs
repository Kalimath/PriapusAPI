namespace MbDevelopment.Greenmaster.BotanicalWebService;

public class Species
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public string[] CommonNames { get; set; }
}