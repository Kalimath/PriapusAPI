using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Base;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public class TaxonSpecies: IIdentifiable<Guid>, ISpecies
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public TaxonGenus Genus { get; set; }
    public string LatinName { get; set; }
    public string Cultivar { get; set; }
    public string Description { get; set; }
}