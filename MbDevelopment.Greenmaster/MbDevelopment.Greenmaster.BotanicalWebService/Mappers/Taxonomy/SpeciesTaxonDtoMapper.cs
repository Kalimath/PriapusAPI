using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;

public class SpeciesTaxonDtoMapper : ITaxonDtoMapper<TaxonSpecies, SpeciesDto>
{
    private readonly IHashids _hashids;

    public SpeciesTaxonDtoMapper(IHashids hashids)
    {
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }

    public SpeciesDto ToDto(TaxonSpecies model)
    {
        return new SpeciesDto()
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            CommonName = model.CommonName,
            TrademarkName = model.TrademarkName,
            Cultivar = model.Cultivar,
            FullLatinName = model.FullLatinName,
            ImageUrl = model.ImageUrl,
            Genus = new BasicTaxonDto()
            {
                Id = _hashids.Encode(model.GenusId),
                Name = model.Genus.LatinName,
                Description = model.Genus.Description
            }
        };
    }

    public BasicTaxonDto ToBasicDto(TaxonSpecies model)
    {
        return new BasicTaxonDto()
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            ParentTaxonId = _hashids.Encode(model.GenusId),
            ParentTaxonType = nameof(model.Genus)
        };
    }

    public TaxonSpecies FromDto(SpeciesDto dto)
    {
        var decodedSpeciesId = _hashids.DecodeSingle(dto.Id);

        return new TaxonSpecies()
        {
            Id = decodedSpeciesId,
            LatinName = dto.Name,
            GenusId = _hashids.DecodeSingle(dto.Genus.Id),
            Description = dto.Description,
            CommonName = dto.CommonName,
            TrademarkName = dto.TrademarkName,
            Cultivar = dto.Cultivar,
            ImageUrl = dto.ImageUrl
        };
    }
}