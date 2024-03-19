using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries.Handlers;

public class GetAllKingdomsHandler : IRequestHandler<GetAllKingdomsQuery, ApiResponse<IEnumerable<KingdomDto>>>
{
    private readonly BotanicalContext _context;
    private readonly IHashids _hashids;
    
    public GetAllKingdomsHandler(BotanicalContext context, IHashids hashids)
    {
        _context = context;
        _hashids = hashids;
    }
    
    public async Task<ApiResponse<IEnumerable<KingdomDto>>> Handle(GetAllKingdomsQuery request, CancellationToken cancellationToken)
    {
        var kingdoms = await _context.TaxonKingdoms.Select(x => new KingdomDto(){HashedId = _hashids.Encode(x.Id), Name = x.LatinName, Description = x.Description}).ToListAsync(cancellationToken);
        return new ApiResponse<IEnumerable<KingdomDto>>()
        {
            Ok = true,
            Data = kingdoms
        };
    }
}