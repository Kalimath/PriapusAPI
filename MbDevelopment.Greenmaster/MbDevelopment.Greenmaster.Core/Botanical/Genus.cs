using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbDevelopment.Greenmaster.Core.Botanical;

public class Genus : ITaxonIdentifier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }
    public required string LatinName { get; set; }
    public string Description { get; set; } = string.Empty;
    
    public ICollection<Species> Species { get; set; } = new List<Species>(); // Collection navigation containing dependents
}