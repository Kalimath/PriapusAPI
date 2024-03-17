using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Base;
using MbDevelopment.Greenmaster.Core.Botanical;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public class TaxonDivision : ITaxonomyItem, IIdentifiable<Guid>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public TaxonKingdom Kingdom { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    public PollinationType PollinationType { get; set; }
    
    public ICollection<TaxonClass> RelatedClasses { get; set; } = new List<TaxonClass>(); // Collection navigation containing dependents
}