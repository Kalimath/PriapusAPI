using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries.Handlers;

public class GetKingdomByIdHandler : IRequestHandler<GetKingdomByIdQuery, ApiResponse<KingdomDto>>
{
    private readonly BotanicalContext _context;
    private readonly IHashids _hashids;
    private readonly KingdomMapper _kingdomMapper;

    public GetKingdomByIdHandler(BotanicalContext context, IHashids hashids)
    {
        _context = context;
        _hashids = hashids;
        _kingdomMapper = new KingdomMapper(hashids);
        
    }

    public async Task<ApiResponse<KingdomDto>> Handle(GetKingdomByIdQuery request, CancellationToken cancellationToken)
    {
        var notFound = new ApiResponse<KingdomDto>(){Ok = false, Error = "Kingdom not found"};
        
        var rawId = _hashids.Decode(request.Id);
        if (rawId.Length == 0) return notFound;
        
        var kingdom = await _context.TaxonKingdoms.FirstOrDefaultAsync(x => x.Id == rawId.First(), cancellationToken);
        if (kingdom == null) return notFound;
        
        return new ApiResponse<KingdomDto>() { Ok = true, Data = _kingdomMapper.ToDto(kingdom) };
    }
}