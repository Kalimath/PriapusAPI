using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Kingdom;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Kingdom;

public class GetKingdomByIdQueryHandler : IRequestHandler<GetKingdomByIdQuery, KingdomDto>
{
    private readonly IRepository<TaxonKingdom> _repository;
    private readonly IHashids _hashids;
    private readonly KingdomTaxonDtoMapper _kingdomTaxonDtoMapper;

    public GetKingdomByIdQueryHandler(IRepository<TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _kingdomTaxonDtoMapper = new KingdomTaxonDtoMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
        
    }

    public async Task<KingdomDto> Handle(GetKingdomByIdQuery request, CancellationToken cancellationToken)
    {
        
        var rawId = _hashids.DecodeSingle(request.Id);
        
        var kingdom = await _repository.GetAsync(x => x.Id == rawId, cancellationToken);
        
        return (kingdom == null ? throw new ValidationException("Kingdom not found") : _kingdomTaxonDtoMapper.ToDto(kingdom))!;
    }
}