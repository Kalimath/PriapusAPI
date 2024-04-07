using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Order;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, OrderDto>
{
    private readonly IRepository<TaxonOrder> _repository;
    private readonly IHashids _hashids;
    private readonly IMapper<TaxonOrder, OrderDto> _mapper;

    public DeleteOrderCommandHandler(IRepository<TaxonOrder> repository, IMapper<TaxonOrder, OrderDto> mapper, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<OrderDto> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        var order = await _repository.GetAsync(i => i.Id == decodedId, cancellationToken);
        if (order == null) throw new KeyNotFoundException($"Order with id {request.Id} not found");
        
        _repository.Delete(order);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.ToDto(order)!;
    }
}