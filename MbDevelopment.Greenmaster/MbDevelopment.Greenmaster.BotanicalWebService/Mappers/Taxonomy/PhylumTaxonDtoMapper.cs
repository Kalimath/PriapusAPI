using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;

public class PhylumTaxonDtoMapper : ITaxonDtoMapper<TaxonPhylum, PhylumDto>
{
    private readonly IHashids _hashids;

    public PhylumTaxonDtoMapper(IHashids hashids)
    {
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }

    public PhylumDto? ToDto(TaxonPhylum model)
    {
        return new PhylumDto
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            Kingdom = MapParentTaxon(model)!
        };
    }

    public BasicTaxonDto ToBasicDto(TaxonPhylum model)
    {
        return new BasicTaxonDto()
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            ParentTaxonId = _hashids.Encode(model.KingdomId),
            ParentTaxonType = nameof(model.Kingdom)
        };
    }

    public TaxonPhylum FromDto(PhylumDto dto)
    {
        return new TaxonPhylum
        {
            Id = _hashids.DecodeSingle(dto.Id),
            LatinName = dto.Name,
            Description = dto.Description
            //Kingdom not mapped
        };
    }

    private KingdomDto MapParentTaxon(TaxonPhylum model)
    {
        return new KingdomDto()
        {
            Id = _hashids.Encode(model.KingdomId)
        };
    }
}