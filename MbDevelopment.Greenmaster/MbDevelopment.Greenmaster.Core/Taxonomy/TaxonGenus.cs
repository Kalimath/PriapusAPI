using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

[Table("Taxonomy.Genera")]
public class TaxonGenus : ITaxonGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public TaxonFamily Family { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    
    public ICollection<TaxonSpecies> RelatedSpecies { get; set; } = new List<TaxonSpecies>(); // Collection navigation containing dependents
}