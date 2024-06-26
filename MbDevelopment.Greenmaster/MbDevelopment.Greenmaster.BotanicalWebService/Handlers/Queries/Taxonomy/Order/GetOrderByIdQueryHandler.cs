using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Order;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Order;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IRepository<TaxonOrder> _repository;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonOrder, OrderDto> _taxonDtoMapper;

    public GetOrderByIdQueryHandler(IRepository<TaxonOrder> repository, ITaxonDtoMapper<TaxonOrder, OrderDto> taxonDtoMapper, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = taxonDtoMapper ?? throw new ArgumentNullException(nameof(taxonDtoMapper));
        
    }

    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var rawId = _hashids.DecodeSingle(request.Id);
        
        var order = await _repository.GetAsync(x => x.Id == rawId, cancellationToken);
        
        return (order == null ? throw new ValidationException("Order not found") : _taxonDtoMapper.ToDto(order))!;
    }
}