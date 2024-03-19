using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries.Handlers;

public class GetAllKingdomsHandler : IRequestHandler<GetAllKingdomsQuery, IEnumerable<KingdomDto>>
{
    private readonly BotanicalContext _context;
    private readonly IHashids _hashids;
    
    public GetAllKingdomsHandler(BotanicalContext context, IHashids hashids)
    {
        _context = context;
        _hashids = hashids;
    }
    
    public async Task<IEnumerable<KingdomDto>> Handle(GetAllKingdomsQuery request, CancellationToken cancellationToken)
    {
        return await _context.TaxonKingdoms.Select(x => new KingdomDto(){HashedId = _hashids.Encode(x.Id), Name = x.LatinName, Description = x.Description}).ToListAsync(cancellationToken);
    }
}