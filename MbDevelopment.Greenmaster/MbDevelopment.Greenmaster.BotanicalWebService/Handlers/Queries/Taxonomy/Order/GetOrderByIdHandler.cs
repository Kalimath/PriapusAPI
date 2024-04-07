using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Order;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Order;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IRepository<TaxonOrder> _repository;
    private readonly IHashids _hashids;
    private readonly IMapper<TaxonOrder, OrderDto> _mapper;

    public GetOrderByIdHandler(IRepository<TaxonOrder> repository, IMapper<TaxonOrder, OrderDto> mapper, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        
    }

    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var rawId = _hashids.DecodeSingle(request.Id);
        
        var order = await _repository.GetAsync(x => x.Id == rawId, cancellationToken);
        
        return (order == null ? throw new ValidationException("Order not found") : _mapper.ToDto(order))!;
    }
}