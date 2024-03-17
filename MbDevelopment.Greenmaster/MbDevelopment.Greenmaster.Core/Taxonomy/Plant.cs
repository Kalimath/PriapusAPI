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

/*public abstract class LandPlant : Plant
{
    protected LandPlant(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected LandPlant(string latinName, string description = "") : base(latinName, description)
    {
    }
}*/

/*public abstract class VascularPlant : LandPlant
{
    protected VascularPlant(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected VascularPlant(string latinName, string description = "") : base(latinName, description)
    {
    }
}*/

/*public abstract class SeedPlant : VascularPlant
{
    protected SeedPlant(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected SeedPlant(string latinName, string description = "") : base(latinName, description)
    {
    }
}*/

/*public class Fern : VascularPlant
{
    protected Fern(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected Fern(string latinName, string description = "") : base(latinName, description)
    {
    }
}*/

/*public class Angiosperm : SeedPlant
{
    // should override auto-property: Flowering -> true
    protected Angiosperm(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected Angiosperm(string latinName, string description = "") : base(latinName, description)
    {
    }
}*/

/*/// Produces seeds without fruits
public class Gymnosperm : SeedPlant
{
    // naaktzadigen -> produces pollen
    
    protected Gymnosperm(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected Gymnosperm(string latinName, string description = "") : base(latinName, description)
    {
    }
}*/

/*public class Ginkgoaceae : Gymnosperm, ITaxonFamily
{
    // like ginkgo
    protected Ginkgoaceae(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected Ginkgoaceae(string latinName, string description = "") : base(latinName, description)
    {
    }

    public static Ginkgoaceae Ginkgo = new("Ginkgo", "Ginkgo");
}

public class Gnetaceae : Gymnosperm, ITaxonFamily
{
    protected Gnetaceae(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected Gnetaceae(string latinName, string description = "") : base(latinName, description)
    {
    }
}*/


/*/// Characterized by having one seed leave upon germination
public class Monocot : Angiosperm
{
    protected Monocot(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected Monocot(string latinName, string description = "") : base(latinName, description)
    {
    }
}*/

/*/// Characterized by having two seed leaves (cotyledons) upon germination
public class Eudicot : Angiosperm
{
    
    protected Eudicot(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected Eudicot(string latinName, string description = "") : base(latinName, description)
    {
    }
}*/

/*public abstract class Asterid : Eudicot
{
    protected Asterid(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected Asterid(string latinName, string description = "") : base(latinName, description)
    {
    }
}*/

/*public abstract class Rosid : Eudicot
{
    
    protected Rosid(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }

    protected Rosid(string latinName, string description = "") : base(latinName, description)
    {
    }
    
   
}*/

