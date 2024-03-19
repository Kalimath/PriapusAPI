using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Requests;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Commands;

public class CreateKingdomCommand : IRequest<ApiResponse<KingdomDto>>
{
    public string LatinName { get; set; }
    public string Description { get; set; }
    public CreateKingdomCommand(CreateKingdomRequest request)
    {
        LatinName = request.Name;
        Description = request.Description;
    }
}