using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

/// <summary>
///  A group of organisms that all descended from a certain common ancestor
/// </summary>
[Table("Taxonomy.Clades")]
public class TaxonClade : ITaxonGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public ITaxonGroup Ancestor { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    
    public ICollection<ITaxonGroup> Descendants { get; set; } = new List<ITaxonGroup>(); // Collection navigation containing dependents
}