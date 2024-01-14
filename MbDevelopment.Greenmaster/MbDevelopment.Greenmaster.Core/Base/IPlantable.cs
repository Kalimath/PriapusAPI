using MbDevelopment.Greenmaster.Core.Botanical;

namespace MbDevelopment.Greenmaster.Core.Base;

public interface IPlantable
{
    ICollection<CommonName> CommonNames {get; set;}
}