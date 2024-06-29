using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;

public class GenusTaxonDtoMapper : ITaxonDtoMapper<TaxonGenus, GenusDto>
{
    private readonly IHashids _hashids;
    
    public GenusTaxonDtoMapper(IHashids hashids)
    {
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }
    
    public GenusDto? ToDto(TaxonGenus model)
    {
        return new GenusDto()
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            Family = new BasicTaxonDto()
            {
                Id = _hashids.Encode(model.FamilyId),
                Name = model.Family.LatinName,
                Description = model.Family.Description
            }
        };
    }

    public BasicTaxonDto? ToBasicDto(TaxonGenus model)
    {
        return new BasicTaxonDto()
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            ParentTaxonId = _hashids.Encode(model.FamilyId),
            ParentTaxonType = nameof(model.Family)
        };
    }

    public TaxonGenus FromDto(GenusDto dto)
    {
        return new TaxonGenus()
        {
            Id = _hashids.DecodeSingle(dto.Id),
            LatinName = dto.Name,
            Description = dto.Description,
            FamilyId = _hashids.DecodeSingle(dto.Family.Id)
        };
    }
}