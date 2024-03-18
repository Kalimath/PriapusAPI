using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS;

public class GetKingdomByIdQueryHandler : IRequestHandler<GetKingdomByIdQuery, KingdomDto>
{
    private readonly BotanicalContext _context;

    public GetKingdomByIdQueryHandler(BotanicalContext context)
    {
        _context = context;
    }

    public async Task<KingdomDto> Handle(GetKingdomByIdQuery request, CancellationToken cancellationToken)
    {
        //TODO: validate request
        var kingdom = await _context.TaxonKingdoms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        //TODO: validate kingdom
        //TODO: create mapper
        return new KingdomDto()
        {
            Id = kingdom!.Id,
            Name = kingdom.LatinName,
            Description = kingdom.Description
        };
    }
}