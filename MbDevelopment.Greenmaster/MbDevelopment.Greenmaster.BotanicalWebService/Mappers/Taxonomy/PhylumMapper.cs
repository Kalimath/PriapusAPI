using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;

public class PhylumMapper : IMapper<TaxonPhylum, PhylumDto>
{
    private readonly IHashids _hashids;

    public PhylumMapper(IHashids hashids)
    {
        _hashids = hashids;
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
        return new KingdomDto
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description
            
        };
    }
}