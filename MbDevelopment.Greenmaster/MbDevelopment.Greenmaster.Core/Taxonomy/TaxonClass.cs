using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

[Table("Taxonomy.Classes")]
public class TaxonClass : ITaxonGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    public int PhylumId { get; set; }
    public TaxonPhylum Phylum { get; set; }
    
    public ICollection<TaxonOrder> RelatedOrders { get; set; } = new List<TaxonOrder>(); // Collection navigation containing dependents
    
}