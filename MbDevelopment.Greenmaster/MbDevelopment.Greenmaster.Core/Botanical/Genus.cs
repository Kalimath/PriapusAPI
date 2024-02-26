using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbDevelopment.Greenmaster.Core.Botanical;

public class Genus : ITaxonIdentifier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }
    public required string LatinName { get; set; }
    public string Description { get; set; } = "/"; //TODO: make nullable or add '/' as default in converter for EF
    
    public ICollection<Species> Species { get; set; } = new List<Species>(); // Collection navigation containing dependents
}