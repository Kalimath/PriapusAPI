using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Extensions;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

[Table("Taxonomy.Species")]
public class TaxonSpecies: ITaxonGroup, ISpecies
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int GenusId { get; set; }
    public TaxonGenus Genus { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }
    
    public string CommonName { get; set; } = string.Empty;
    public string TrademarkName { get; set; } = string.Empty;
    public string Cultivar { get; set; } = string.Empty;
    public string FullLatinName => $"{Genus.LatinName.FirstCharToUpper()} {LatinName.FirstCharToUpper()}" + (!string.IsNullOrEmpty(Cultivar)?$" \'{Cultivar.ToTitleCase()}\'":"");
    
    //TODO: add characteristics properties
    //TODO: add (max)dimensions properties
    
}