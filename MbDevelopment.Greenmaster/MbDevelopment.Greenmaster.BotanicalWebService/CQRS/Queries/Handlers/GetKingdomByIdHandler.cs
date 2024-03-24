using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries.Handlers;

public class GetKingdomByIdHandler : IRequestHandler<GetKingdomByIdQuery, KingdomDto>
{
    private readonly IRepository<TaxonKingdom> _repository;
    private readonly IHashids _hashids;
    private readonly KingdomMapper _kingdomMapper;

    public GetKingdomByIdHandler(IRepository<TaxonKingdom> repository, IHashids hashids)
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