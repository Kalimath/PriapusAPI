using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Order;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderDto>
{
    private readonly IRepository<TaxonOrder> _repository;
    private readonly IRepository<TaxonClass> _classRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonOrder, OrderDto> _taxonDtoMapper;

    public UpdateOrderCommandHandler(IRepository<TaxonOrder> repository,IRepository<TaxonClass> classRepo, ITaxonDtoMapper<TaxonOrder, OrderDto> taxonDtoMapper, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _classRepo = classRepo ?? throw new ArgumentNullException(nameof(classRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = taxonDtoMapper ?? throw new ArgumentNullException(nameof(taxonDtoMapper));
    }

    public async Task<OrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        //validation in pipeline
        var rawOrderId = _hashids.DecodeSingle(request.Id);
        var rawClassId = _hashids.DecodeSingle(request.ClassId);
        
        var requestedOrder = await _repository.GetAsync(k => k.Id == rawOrderId, cancellationToken);
        if (requestedOrder == null) throw new KeyNotFoundException($"Order with id {request.Id} not found");
        
        var requestedClass = await _classRepo.GetAsync(k => k.Id == rawClassId, cancellationToken);
        if (requestedClass == null) throw new KeyNotFoundException($"Class with id {request.ClassId} not found");
        
        UpdateModel(requestedOrder, requestedClass, request);

        _repository.Update(requestedOrder);
        await _repository.SaveChangesAsync(cancellationToken);
        
        return _taxonDtoMapper.ToDto(requestedOrder)!;
    }

    private static void UpdateModel(TaxonOrder initialOrder, TaxonClass updatedClass, UpdateOrderCommand updatedValues)
    {
        initialOrder.LatinName = updatedValues.Name;
        initialOrder.Description = updatedValues.Description;
        initialOrder.ClassId = updatedClass.Id;
        initialOrder.Class = updatedClass;
    }
}