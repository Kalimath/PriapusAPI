using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Order;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, OrderDto>
{
    private readonly IRepository<TaxonOrder> _repository;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonOrder, OrderDto> _taxonDtoMapper;

    public DeleteOrderCommandHandler(IRepository<TaxonOrder> repository, ITaxonDtoMapper<TaxonOrder, OrderDto> taxonDtoMapper, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = taxonDtoMapper ?? throw new ArgumentNullException(nameof(taxonDtoMapper));
    }
    
    public async Task<OrderDto> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        var order = await _repository.GetAsync(i => i.Id == decodedId, cancellationToken);
        if (order == null) throw new KeyNotFoundException($"Order with id {request.Id} not found");
        
        _repository.Delete(order);
        await _repository.SaveChangesAsync(cancellationToken);
        return _taxonDtoMapper.ToDto(order)!;
    }
}