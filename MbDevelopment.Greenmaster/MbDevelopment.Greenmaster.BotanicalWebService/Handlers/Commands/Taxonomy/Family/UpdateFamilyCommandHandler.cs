using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Family;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Family;

public class UpdateFamilyCommandHandler : IRequestHandler<UpdateFamilyCommand, FamilyDto>
{
    private readonly IRepository<TaxonFamily> _familyRepo;
    private readonly IRepository<TaxonOrder> _orderRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonFamily, FamilyDto> _taxonDtoMapper;
    
    public UpdateFamilyCommandHandler(IRepository<TaxonFamily> familyRepo, IRepository<TaxonOrder> orderRepo, IHashids hashids)
    {
        _familyRepo = familyRepo?? throw new ArgumentNullException(nameof(familyRepo));
        _orderRepo = orderRepo?? throw new ArgumentNullException(nameof(orderRepo));
        _hashids = hashids?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = new FamilyTaxonDtoMapper(hashids);
    }
    public async Task<FamilyDto> Handle(UpdateFamilyCommand request, CancellationToken cancellationToken)
    {
        var decodedFamilyId = _hashids.DecodeSingle(request.Id);
        var decodedOrderId = _hashids.DecodeSingle(request.OrderId);
        
        var requestedFamily = await _familyRepo.GetAsync(k => k.Id == decodedFamilyId, cancellationToken);
        if (requestedFamily == null) throw new ValidationException($"Family with id {request.Id} not found");
        
        var requestedOrder = await _orderRepo.GetAsync(k => k.Id == decodedOrderId, cancellationToken);
        if (requestedOrder == null) throw new ValidationException($"Order with id {request.OrderId} not found");
        
        UpdateModel(requestedFamily, request, requestedOrder);
        
        _familyRepo.Update(requestedFamily);
        await _familyRepo.SaveChangesAsync(cancellationToken);
        
        return _taxonDtoMapper.ToDto(requestedFamily)!;
    }

    private static void UpdateModel(TaxonFamily original, UpdateFamilyCommand request, TaxonOrder requestedOrder)
    {
        original.LatinName = request.Name;
        original.Description = request.Description;
        original.OrderId = requestedOrder.Id;
        original.Order = requestedOrder;
    }
}