using MbDevelopment.Greenmaster.Core.Base;

namespace MbDevelopment.Greenmaster.Core.Botanical;

public interface ITaxonIdentifier : IIdentifiable<int>
{
    public string LatinName { get; set; }   
    public string Description { get; set; }
    
}