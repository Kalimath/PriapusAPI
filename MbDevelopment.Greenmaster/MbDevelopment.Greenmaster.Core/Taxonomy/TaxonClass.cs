using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Base;
using MbDevelopment.Greenmaster.Core.Botanical;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public class TaxonClass : ITaxonomyItem, IIdentifiable<Guid>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public TaxonDivision Division { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    
    public ICollection<TaxonOrder> RelatedOrders { get; set; } = new List<TaxonOrder>(); // Collection navigation containing dependents
}