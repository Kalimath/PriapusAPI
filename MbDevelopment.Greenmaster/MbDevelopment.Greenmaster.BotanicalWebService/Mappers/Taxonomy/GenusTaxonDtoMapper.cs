using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;

public class GenusTaxonDtoMapper : ITaxonDtoMapper<TaxonGenus, GenusDto>
{
    public GenusDto? ToDto(TaxonGenus model)
    {
        throw new NotImplementedException();
    }

    public BasicTaxonDto? ToBasicDto(TaxonGenus model)
    {
        throw new NotImplementedException();
    }

    public TaxonGenus FromDto(GenusDto dto)
    {
        throw new NotImplementedException();
    }
}