using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries;

public class GetKingdomByIdQuery(string id) : IRequest<ApiResponse<KingdomDto>>
{
    public string Id { get; set; } = id;
}