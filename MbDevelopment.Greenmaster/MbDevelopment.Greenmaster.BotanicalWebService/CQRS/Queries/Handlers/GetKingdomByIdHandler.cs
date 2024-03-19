using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries.Handlers;

public class GetKingdomByIdHandler : IRequestHandler<GetKingdomByIdQuery, KingdomDto>
{
    private readonly BotanicalContext _context;
    private readonly KingdomMapper _kingdomMapper;

    public GetKingdomByIdHandler(BotanicalContext context, IHashids hashids)
    {
        _context = context;
        _kingdomMapper = new KingdomMapper(hashids);
        
    }

    public async Task<KingdomDto> Handle(GetKingdomByIdQuery request, CancellationToken cancellationToken)
    {
        //TODO: validate request
        var kingdom = await _context.TaxonKingdoms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        //TODO: validate kingdom
        if (kingdom == null) return null;
         
        return _kingdomMapper.ToDto(kingdom);
    }
}