using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers;

public class KingdomMapper(IHashids hashids)
{
    public KingdomDto? ToDto(TaxonKingdom kingdom)
    {
        return new KingdomDto()
        {
            HashedId = hashids.Encode(kingdom.Id),
            Name = kingdom.LatinName,
            Description = kingdom.Description
        };
    }

    public TaxonKingdom FromDto(KingdomDto kingdomDto)
    {
        return new TaxonKingdom()
        {
            Id = hashids.DecodeSingle(kingdomDto.HashedId),
            LatinName = kingdomDto.Name,
            Description = kingdomDto.Description
        };
    }
}