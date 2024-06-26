using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Family;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Family;

public class GetFamilyByIdQueryHandler : IRequestHandler<GetFamilyByIdQuery, FamilyDto>
{
    private readonly IRepository<TaxonFamily> _familyRepo;
    private readonly IRepository<TaxonOrder> _orderRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonFamily, FamilyDto> _taxonDtoMapper;
    
    public GetFamilyByIdQueryHandler(IRepository<TaxonFamily> familyRepo, IRepository<TaxonOrder> orderRepo, IHashids hashids)
    {
        _familyRepo = familyRepo?? throw new ArgumentNullException(nameof(familyRepo));
        _orderRepo = orderRepo ?? throw new ArgumentNullException(nameof(orderRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = new FamilyTaxonDtoMapper(hashids);
    }
    
    public async Task<FamilyDto> Handle(GetFamilyByIdQuery request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        
        var requestedFamily = await _familyRepo.GetAsync(x => x.Id == decodedId, cancellationToken);
        if (requestedFamily == null) throw new KeyNotFoundException($"Family with id: {request.Id} not found");
        
        requestedFamily.Order = (await _orderRepo.GetAsync(x => x.Id == requestedFamily.OrderId, cancellationToken))!;
        
        return _taxonDtoMapper.ToDto(requestedFamily)!;
    }
}