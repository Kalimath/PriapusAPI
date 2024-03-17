namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public interface ITaxonomyItem
{
    public string LatinName { get; set; }   
    //TODO: public string CommonName { get; set; }   
    public string Description { get; set; }
    
}