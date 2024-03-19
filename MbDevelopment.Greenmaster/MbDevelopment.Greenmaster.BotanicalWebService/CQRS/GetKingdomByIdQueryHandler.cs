using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS;

public class GetKingdomByIdQueryHandler : IRequestHandler<GetKingdomByIdQuery, KingdomDto>
{
    private readonly BotanicalContext _context;
    private readonly KingdomMapper _kingdomMapper;

    public GetKingdomByIdQueryHandler(BotanicalContext context, IHashids hashids)
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

public class KingdomMapper(IHashids hashids)
{
    public KingdomDto ToDto(TaxonKingdom kingdom)
    {
        return new KingdomDto()
        {
            HashedId = hashids.Encode(kingdom.Id),
            Name = kingdom.LatinName,
            Description = kingdom.Description
        };
    }
}