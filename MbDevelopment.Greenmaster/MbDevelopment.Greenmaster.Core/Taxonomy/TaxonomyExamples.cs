namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public static class TaxonomyExamples
{
    //needs to be converted to tables in db
    
    public static TaxonKingdom Plants = new()
    {
        LatinName = "Plantea",
        Description = "Plants kingdom",
    };

    public static TaxonPhylum LandPlants = new()
    {
        Kingdom = Plants,
        LatinName = "Embryophytes",
        Description = "The embryophytes are informally called \"land plants\" because they thrive primarily in terrestrial habitats (despite some members having evolved secondarily to live once again in semiaquatic/aquatic habitats), while the related green algae are primarily aquatic. " +
                      "Embryophytes are complex multicellular eukaryotes with specialized reproductive organs. " +
                      "The name derives from their innovative characteristic of nurturing the young embryo sporophyte during the early stages of its multicellular development within the tissues of the parent gametophyte.",
    };

    public static TaxonClass SeedPlants = new()
    {
        Phylum = LandPlants,
        LatinName = "Spermatofyta",
        Description = "Any plant that produces seeds"
    };

    public static TaxonOrder Liliales = new()
    {
        Class = SeedPlants,
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

    public static TaxonClade FloweringPlants = new()
    {
        Ancestor = SeedPlants,
        LatinName = "AngioSpermae",
        Description = "Flowering plants",
        Descendants = new List<ITaxonGroup> {Liliaceae}
    };

    public static TaxonClade Monocots = new()
    {
        Ancestor = FloweringPlants,
        LatinName = "Monocotyledon",
        Description = "Grass and grass-like flowering plants (angiosperms)",
        Descendants = new List<ITaxonGroup> {Liliaceae}
    };

    public static TaxonClade Eudicots = new()
    {
        Ancestor = FloweringPlants,
        LatinName = "Eudicotidae",
        Description = "Plants mainly characterized by having two seed leaves (cotyledons) upon germination. " +
                      "Eudicots include sunflower, dandelion, forget-me-not, cabbage, apple, buttercup, maple, and macadamia.",
        Descendants = new List<ITaxonGroup> {}
    };
}