using System.ComponentModel.DataAnnotations;
using MbDevelopment.Greenmaster.Core.Base;
using MbDevelopment.Greenmaster.Core.Botanical;

namespace MbDevelopment.Greenmaster.Core.Taxonomy;
public abstract class Plant : IIdentifiable<Guid>, ITaxonomyItem
{
    [Key]
    public Guid Id { get; set; }
    public string LatinName { get; set; }
    public string Description { get; set; }

    protected Plant(Guid id, string latinName, string description = "")
    {
        Id = id != Guid.Empty ? id : throw new ArgumentException("Id cannot be empty", nameof(id));
        LatinName = latinName?? throw new ArgumentNullException(nameof(latinName));
        Description = description ?? "";
    }
}

public abstract class LandPlant : Plant
{
    protected LandPlant(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }
}

public abstract class VascularPlant : LandPlant
{
    protected VascularPlant(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }
}

public abstract class SeedPlant : VascularPlant
{
    protected SeedPlant(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }
}

public abstract class Fern : VascularPlant
{
    protected Fern(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }
}

public abstract class Angiosperm : SeedPlant
{
    // should override auto-property: Flowering -> true
    protected Angiosperm(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }
}

public abstract class Gymnosperm : SeedPlant
{
    // naaktzadigen -> produces pollen
    // like ginkgo
    // they produce seeds without fruits
    protected Gymnosperm(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }
}

public abstract class Monocot : Angiosperm
{
    // characterized by having one seed leave upon germination
    protected Monocot(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }
}

public abstract class Eudicot : Angiosperm
{
    // characterized by having two seed leaves (cotyledons) upon germination
    protected Eudicot(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }
}

public abstract class Asterid : Eudicot
{
    protected Asterid(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }
}

public abstract class Rosid : Eudicot
{
    protected Rosid(Guid id, string latinName, string description = "") : base(id, latinName, description)
    {
    }
}




