using System.ComponentModel.DataAnnotations;
using MbDevelopment.Greenmaster.Core.Base;

namespace MbDevelopment.Greenmaster.Core.Botanical;

public class Species : ITaxonIdentifier, IPlantable
{
    [Key]
    public required int Id { get; set; }
    public required string LatinName { get; set; }
    public string? Description { get; set; }
    public ICollection<CommonName> CommonNames { get; set; } = new List<CommonName>(); // Collection navigation containing dependents
    
    public int GenusId { get; set; } // Required foreign key property
    
    public Genus Genus { get; set; } // Required reference navigation to principal
}