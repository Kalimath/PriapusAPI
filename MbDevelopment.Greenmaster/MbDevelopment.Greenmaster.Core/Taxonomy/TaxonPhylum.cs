using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

/// <summary>
/// A group of organisms that all descended from a certain common ancestor
/// </summary>
[Table("Taxonomy.Phyla")]
public class TaxonPhylum : ITaxonGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public Guid TaxonKingdomId { get; set; } // Required foreign key property
    public TaxonKingdom Kingdom { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    
    public ICollection<TaxonClass> RelatedClasses { get; set; } = new List<TaxonClass>(); // Collection navigation containing dependents
}