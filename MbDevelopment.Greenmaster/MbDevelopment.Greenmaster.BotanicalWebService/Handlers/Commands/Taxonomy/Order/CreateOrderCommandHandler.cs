using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Order;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
{
    private readonly IRepository<TaxonOrder> _repository;
    private readonly IRepository<TaxonClass> _classRepo;
    private readonly ITaxonDtoMapper<TaxonOrder, OrderDto> _taxonDtoMapper;
    private readonly IHashids _hashids;
    
    public CreateOrderCommandHandler(IRepository<TaxonOrder> repository, IRepository<TaxonClass> classRepo, ITaxonDtoMapper<TaxonOrder, OrderDto> taxonDtoMapper, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _classRepo = classRepo ?? throw new ArgumentNullException(nameof(classRepo));
        _taxonDtoMapper = taxonDtoMapper ?? throw new ArgumentNullException(nameof(taxonDtoMapper));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }
    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var rawId = _hashids.DecodeSingle(request.ClassId);
        var requestedClass = await _classRepo.GetAsync(c => c.Id == rawId, cancellationToken) ?? throw new KeyNotFoundException("Class not found");
        var newOrder = new TaxonOrder {LatinName = request.Name, Description = request.Description, Class = requestedClass};
        _repository.Add(newOrder);
        await _repository.SaveChangesAsync(cancellationToken);
        
        var createdItem = _repository.Query(x => x.LatinName == request.Name && x.Description == request.Description).FirstOrDefault();
        if (createdItem == null) throw new Exception("Failed to get created order");
        return _taxonDtoMapper.ToDto(createdItem)!;
    }
}