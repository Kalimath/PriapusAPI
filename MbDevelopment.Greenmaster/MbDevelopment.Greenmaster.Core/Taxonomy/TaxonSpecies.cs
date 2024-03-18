using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Extensions;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

[Table("Taxonomy.Species")]
public class TaxonSpecies: ITaxonGroup, ISpecies
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public TaxonGenus Genus { get; set; }
    public string LatinName { get; set; }
    public string FullLatinName => $"{Genus.LatinName.FirstCharToUpper()} {LatinName.FirstCharToUpper()}" + (!string.IsNullOrEmpty(Cultivar)?$" \'{Cultivar.ToTitleCase()}\'":"");
    public string Cultivar { get; set; }
    public string Description { get; set; }
}