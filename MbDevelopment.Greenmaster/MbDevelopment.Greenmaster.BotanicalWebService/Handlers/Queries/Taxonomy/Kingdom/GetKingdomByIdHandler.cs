using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Kingdom;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Kingdom;

public class GetKingdomByIdHandler : IRequestHandler<GetKingdomByIdQuery, KingdomDto>
{
    private readonly IRepository<Core.Taxonomy.TaxonKingdom> _repository;
    private readonly IHashids _hashids;
    private readonly KingdomMapper _kingdomMapper;

    public GetKingdomByIdHandler(IRepository<Core.Taxonomy.TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _kingdomMapper = new KingdomMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
        
    }

    public async Task<KingdomDto> Handle(GetKingdomByIdQuery request, CancellationToken cancellationToken)
    {
        
        var rawId = _hashids.DecodeSingle(request.Id);
        
        var kingdom = await _repository.GetAsync(x => x.Id == rawId, cancellationToken);
        
        return (kingdom == null ? throw new ValidationException("Kingdom not found") : _kingdomMapper.ToDto(kingdom))!;
    }
}