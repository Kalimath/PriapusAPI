using MbDevelopment.Greenmaster.Core.Base;

namespace MbDevelopment.Greenmaster.BotanicalWebService;

public interface ITaxonIdentifier : IIdentifiable<int>
{
    public string LatinName { get; set; }   
    public string? Description { get; set; }
    
}