using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Base;
using MbDevelopment.Greenmaster.Core.Botanical;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public class TaxonOrder : ITaxonomyItem, IIdentifiable<Guid>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public TaxonClass Class { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    
    public ICollection<TaxonFamily> RelatedFamilies { get; set; } = new List<TaxonFamily>(); // Collection navigation containing dependents
}