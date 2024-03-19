using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Commands.Handlers;

public class CreateKingdomHandler : IRequestHandler<CreateKingdomCommand, ApiResponse<KingdomDto>>
{
    private readonly BotanicalContext _context;
    private readonly KingdomMapper _mapper;
    
    public CreateKingdomHandler(BotanicalContext context, IHashids hashids)
    {
        _context = context;
        _mapper = new KingdomMapper(hashids);
    }
    public async Task<ApiResponse<KingdomDto>> Handle(CreateKingdomCommand request, CancellationToken cancellationToken)
    {
        var createdItem = _context.TaxonKingdoms.Add(new TaxonKingdom(){LatinName = request.LatinName, Description = request.Description});
        await _context.SaveChangesAsync(cancellationToken);
        return new ApiResponse<KingdomDto>()
        {
            Ok = true,
            Data = _mapper.ToDto(createdItem.Entity)
        };
    }
}