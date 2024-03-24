using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers;

public class KingdomMapper(IHashids hashids) : IMapper<TaxonKingdom, KingdomDto>
{
    public KingdomDto? ToDto(TaxonKingdom model)
    {
        return new KingdomDto()
        {
            Id = hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description
        };
    }

    public TaxonKingdom FromDto(KingdomDto kingdomDto)
    {
        return new TaxonKingdom()
        {
            Id = hashids.DecodeSingle(kingdomDto.Id),
            LatinName = kingdomDto.Name,
            Description = kingdomDto.Description
        };
    }
}