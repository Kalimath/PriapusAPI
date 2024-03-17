using MbDevelopment.Greenmaster.Core.Botanical;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public static class TaxonomyExamples
{
    //needs to be converted to tables in db
    
    public static TaxonKingdom Plants = new()
    {
        LatinName = "Plantea",
        Description = "Plantea",
    };

    public static TaxonDivision Angiosperms = new()
    {
        Kingdom = Plants,
        LatinName = "AngioSpermae",
        Description = "Flowering plants",
        PollinationType = PollinationType.Wind,
    };

    public static TaxonClass MonoCots = new()
    {
        Division = Angiosperms,
        LatinName = "Monocotyledon",
        Description = "Liliopsida"
    };

    public static TaxonOrder Liliales = new()
    {
        Class = MonoCots,
        LatinName = "Liliales",
        Description = "Predominantly perennial erect or twining herbaceous and climbing plants"
    };
    
    public static TaxonFamily Liliaceae = new()
    {
        Order = Liliales,
        LatinName = "Liliaceae",
        Description = "Bulbous geophytes with large flowers"
    };
    
    public static TaxonGenus Lily = new()
    {
        Family = Liliaceae,
        LatinName = "Lilium",
        Description = "Herbaceous plants with large flowers grown from bulbs"
    };
    
    public static TaxonSpecies OrangeLily = new()
    {
        Genus = Lily,
        LatinName = "Bulbiferum",
        Description = "Herbaceous European lily"
    };
}