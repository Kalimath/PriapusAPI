using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MbDevelopment.Greenmaster.Core.Base;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;

public class Plant : IIdentifiable<Guid>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public ISpecies Specie { get; set; }
    public string Description { get; set; }

    public Plant(Guid id, ISpecies specie, string description = "")
    {
        Id = id != Guid.Empty ? id : throw new ArgumentException("Id cannot be empty", nameof(id));
        Specie = specie ?? throw new ArgumentNullException(nameof(specie));
        Description = description ?? "";
    }

    public Plant(ISpecies specie, string description = "") : this(Guid.NewGuid(), specie, description)
    {
    }
}

