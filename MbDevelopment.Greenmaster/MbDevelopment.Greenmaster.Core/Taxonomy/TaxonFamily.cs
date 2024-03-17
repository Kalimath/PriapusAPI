using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Base;
using MbDevelopment.Greenmaster.Core.Botanical;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public class TaxonFamily : ITaxonomyItem, IIdentifiable<Guid>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public TaxonOrder Order { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    
    public ICollection<TaxonGenus> RelatedGenera { get; set; } = new List<TaxonGenus>(); // Collection navigation containing dependents
}