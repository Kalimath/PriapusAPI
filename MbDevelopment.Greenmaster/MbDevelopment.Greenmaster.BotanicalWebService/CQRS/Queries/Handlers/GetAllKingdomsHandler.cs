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

public class GetAllKingdomsHandler : IRequestHandler<GetAllKingdomsQuery, IEnumerable<KingdomDto>>
{
    private readonly IRepository<TaxonKingdom> _repository;
    private readonly KingdomMapper _mapper;
    
    public GetAllKingdomsHandler(IRepository<TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository;
        _mapper = new KingdomMapper(hashids); 
    }
    
    public async Task<IEnumerable<KingdomDto>> Handle(GetAllKingdomsQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.All().Select(x => _mapper.ToDto(x)).ToListAsync(cancellationToken))!;
    }
}