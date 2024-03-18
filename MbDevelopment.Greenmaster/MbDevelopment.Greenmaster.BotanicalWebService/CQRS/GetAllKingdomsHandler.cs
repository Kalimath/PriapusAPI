using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS;

public class GetAllKingdomsHandler : IRequestHandler<GetAllKingdomsQuery, IEnumerable<KingdomDto>>
{
    private readonly BotanicalContext _context;
    
    public GetAllKingdomsHandler(BotanicalContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<KingdomDto>> Handle(GetAllKingdomsQuery request, CancellationToken cancellationToken)
    {
        return await _context.TaxonKingdoms.Select(x => new KingdomDto(){Id = x.Id, Name = x.LatinName, Description = x.Description}).ToListAsync(cancellationToken);
    }
}