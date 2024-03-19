using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Base;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public class Plant : IIdentifiable<int>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public ISpecies Specie { get; set; }
    public string Description { get; set; }

    public Plant(ISpecies specie, string description = "")
    {
        Specie = specie ?? throw new ArgumentNullException(nameof(specie));
        Description = description ?? "";
    }

    public Plant(int id, ISpecies specie, string description = "") : this(specie, description)
    {
        Id = id > 0 ? id : throw new ArgumentException("Id cannot be empty", nameof(id));
        
    }
}

