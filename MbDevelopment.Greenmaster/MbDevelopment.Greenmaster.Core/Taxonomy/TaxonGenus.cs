using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Base;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public class TaxonGenus : ITaxonomyItem, IIdentifiable<Guid>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public TaxonFamily Family { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    
    public ICollection<TaxonSpecies> RelatedSpecies { get; set; } = new List<TaxonSpecies>(); // Collection navigation containing dependents
}