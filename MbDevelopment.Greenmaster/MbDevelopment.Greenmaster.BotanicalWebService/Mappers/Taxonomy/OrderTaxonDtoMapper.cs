using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;

public class OrderTaxonDtoMapper : ITaxonDtoMapper<TaxonOrder, OrderDto>
{
    private readonly IHashids _hashids;

    public OrderTaxonDtoMapper(IHashids hashids)
    {
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }

    public OrderDto ToDto(TaxonOrder model)
    {
        return new OrderDto
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            Class = new BasicTaxonDto()
            {
                Id = _hashids.Encode(model.ClassId),
                Name = model.Class.LatinName,
                Description = model.Class.Description
            }
        };
    }

    public BasicTaxonDto ToBasicDto(TaxonOrder model)
    {
        return new BasicTaxonDto
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            ParentTaxonId = _hashids.Encode(model.ClassId),
            ParentTaxonType = nameof(model.Class)
        };
    }

    public TaxonOrder FromDto(OrderDto orderDto)
    {
        return new TaxonOrder()
        {
            Id = _hashids.DecodeSingle(orderDto.Id),
            LatinName = orderDto.Name,
            Description = orderDto.Description
        };
    }
}