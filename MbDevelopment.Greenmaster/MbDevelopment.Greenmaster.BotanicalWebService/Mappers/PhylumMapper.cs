using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers;

public class PhylumMapper : IMapper<TaxonPhylum, PhylumDto>
{
    private readonly KingdomMapper _kingdomMapper;
    private readonly IHashids _hashids;

    public PhylumMapper(IHashids hashids)
    {
        _hashids = hashids;
        _kingdomMapper = new KingdomMapper(hashids);
    }

    public PhylumDto? ToDto(TaxonPhylum model)
    {
        var kingdomDto = _kingdomMapper.ToDto(model.Kingdom);
        return new PhylumDto
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            Kingdom = kingdomDto!
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
}