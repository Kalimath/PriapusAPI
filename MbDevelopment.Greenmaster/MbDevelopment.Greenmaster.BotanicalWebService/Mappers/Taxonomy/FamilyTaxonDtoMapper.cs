using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;

public class FamilyTaxonDtoMapper : ITaxonDtoMapper<TaxonFamily, FamilyDto>
{
    private readonly IHashids _hashids;
    
    public FamilyTaxonDtoMapper(IHashids hashids)
    {
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }

    public FamilyDto? ToDto(TaxonFamily model)
    {
        return new FamilyDto()
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            Order = new BasicTaxonDto()
            {
                Id = _hashids.Encode(model.OrderId)
            }
        };
    }

    public BasicTaxonDto ToBasicDto(TaxonFamily model)
    {
        return new BasicTaxonDto()
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            ParentTaxonId = _hashids.Encode(model.OrderId),
            ParentTaxonType = nameof(model.Order)
        };
    }

    public TaxonFamily FromDto(FamilyDto dto)
    {
        return new TaxonFamily()
        {
            Id = _hashids.DecodeSingle(dto.Id),
            LatinName = dto.Name,
            Description = dto.Description
            //Order not mapped
        };
    }
}