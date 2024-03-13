using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Base;

namespace MbDevelopment.Greenmaster.Core.Botanical;

public class Species : ITaxonomyItem, IPlantable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }
    public required string LatinName { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<CommonName> CommonNames { get; set; } = new List<CommonName>(); // Collection navigation containing dependents
    
    public int GenusId { get; set; } // Required foreign key property
    
    public Genus Genus { get; set; } // Required reference navigation to principal
}