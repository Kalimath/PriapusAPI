using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Family;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Family;

public class CreateFamilyCommandHandler : IRequestHandler<CreateFamilyCommand, FamilyDto>
{
    private readonly IRepository<TaxonFamily> _familyRepo;
    private readonly IRepository<TaxonOrder> _orderRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonFamily, FamilyDto> _taxonDtoMapper;

    public CreateFamilyCommandHandler(IRepository<TaxonFamily> familyRepo, IRepository<TaxonOrder> orderRepo, IHashids hashids)
    {
        _familyRepo = familyRepo ?? throw new ArgumentNullException(nameof(familyRepo));
        _orderRepo = orderRepo ?? throw new ArgumentNullException(nameof(orderRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = new FamilyTaxonDtoMapper(hashids);
    }

    public async Task<FamilyDto> Handle(CreateFamilyCommand request, CancellationToken cancellationToken)
    {
        if (_familyRepo.Exists(x => x.LatinName == request.Name)) throw new ArgumentException($"Family with name: {request.Name} already exists");
        var decodedOrderId = _hashids.DecodeSingle(request.OrderId);
        var requestedOrder = await _orderRepo.GetAsync(x => x.Id == decodedOrderId, cancellationToken);
        if (requestedOrder == null) throw new KeyNotFoundException($"Order with id: {request.OrderId} not found");
        var familyExistsWithName = await _familyRepo.GetAsync(x => x.LatinName == request.Name, cancellationToken);
        if (familyExistsWithName is not null) return _taxonDtoMapper.ToDto(familyExistsWithName)!;
        var newFamily = new TaxonFamily()
        {
            LatinName = request.Name,
            Description = request.Description,
            OrderId = requestedOrder.Id
        };
        _familyRepo.Add(newFamily);
        await _familyRepo.SaveChangesAsync(cancellationToken);
        var createdItem = _familyRepo.Query(x => x.LatinName == request.Name && x.Description == request.Description).FirstOrDefault();
        if (createdItem == null) throw new Exception("Failed to get created family");
        return _taxonDtoMapper.ToDto(createdItem);
    }
}