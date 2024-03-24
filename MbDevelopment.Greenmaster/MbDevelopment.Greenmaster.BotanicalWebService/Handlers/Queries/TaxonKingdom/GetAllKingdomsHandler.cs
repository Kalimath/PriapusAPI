using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Contracts.Queries.TaxonKingdom;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.TaxonKingdom;

public class GetAllKingdomsHandler : IRequestHandler<GetAllKingdomsQuery, IEnumerable<KingdomDto>>
{
    private readonly IRepository<Core.Taxonomy.TaxonKingdom> _repository;
    private readonly KingdomMapper _mapper;
    
    public GetAllKingdomsHandler(IRepository<Core.Taxonomy.TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository;
        _mapper = new KingdomMapper(hashids); 
    }
    
    public async Task<IEnumerable<KingdomDto>> Handle(GetAllKingdomsQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.All().Select(x => _mapper.ToDto(x)).ToListAsync(cancellationToken))!;
    }
}