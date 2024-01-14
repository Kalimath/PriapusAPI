using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MbDevelopment.Greenmaster.Core.Botanical;

public class CommonName
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required LanguageIsoCodes[] UsedByLanguages { get; set; } = [LanguageIsoCodes.EN];
    
    public int SpeciesId { get; set; } // Required foreign key property
    
    public Species Species { get; set; } // Required reference navigation to principal
}