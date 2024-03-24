using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Contracts.Queries.TaxonKingdom;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.TaxonKingdom;

public class GetKingdomByIdHandler : IRequestHandler<GetKingdomByIdQuery, KingdomDto>
{
    private readonly IRepository<Core.Taxonomy.TaxonKingdom> _repository;
    private readonly IHashids _hashids;
    private readonly KingdomMapper _kingdomMapper;

    public GetKingdomByIdHandler(IRepository<Core.Taxonomy.TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository;
        _hashids = hashids;
        _kingdomMapper = new KingdomMapper(hashids);
        
    }

    public async Task<KingdomDto> Handle(GetKingdomByIdQuery request, CancellationToken cancellationToken)
    {
        
        var rawId = _hashids.DecodeSingle(request.Id);
        
        var kingdom = await _repository.GetAsync(x => x.Id == rawId, cancellationToken);
        
        return (kingdom == null ? throw new ValidationException("Kingdom not found") : _kingdomMapper.ToDto(kingdom))!;
    }
}