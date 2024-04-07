using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;

public class OrderMapper : IMapper<TaxonOrder, OrderDto>
{
    private readonly IHashids _hashids;

    public OrderMapper(IHashids hashids)
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
            Class = new ClassDto(){Id = _hashids.Encode(model.ClassId)}
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