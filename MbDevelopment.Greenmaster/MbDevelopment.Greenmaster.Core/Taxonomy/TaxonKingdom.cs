using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

[Table("Taxonomy.Kingdoms")]
public class TaxonKingdom : ITaxonGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    public ICollection<TaxonPhylum> RelatedPhyla { get; set; } = new List<TaxonPhylum>(); // Collection navigation containing dependents
}