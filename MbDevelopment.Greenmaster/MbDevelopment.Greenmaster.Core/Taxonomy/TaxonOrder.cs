using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

[Table("Taxonomy.Orders")]
public class TaxonOrder : ITaxonGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    public int ClassId { get; set; }
    public TaxonClass Class { get; set; }
    
    public ICollection<TaxonFamily> RelatedFamilies { get; set; } = new List<TaxonFamily>(); // Collection navigation containing dependents
    
}