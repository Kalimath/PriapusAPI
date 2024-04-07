using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;

public class KingdomMapper : IMapper<TaxonKingdom, KingdomDto>
{
    private readonly IHashids _hashids;

    public KingdomMapper(IHashids hashids)
    {
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }

    public KingdomDto? ToDto(TaxonKingdom model)
    {
        return new KingdomDto
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description
        };
    }

    public BasicTaxonDto? ToBasicDto(TaxonKingdom model)
    {
        return new BasicTaxonDto()
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            ParentTaxonId = null!,
            ParentTaxonType = null!
        };
    }

    public TaxonKingdom FromDto(KingdomDto kingdomDto)
    {
        return new TaxonKingdom
        {
            Id = _hashids.DecodeSingle(kingdomDto.Id),
            LatinName = kingdomDto.Name,
            Description = kingdomDto.Description
        };
    }
}