using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

[Table("Taxonomy.Families")]
public class TaxonFamily : ITaxonGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public TaxonOrder Order { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    
    public ICollection<TaxonGenus> RelatedGenera { get; set; } = new List<TaxonGenus>(); // Collection navigation containing dependents
}