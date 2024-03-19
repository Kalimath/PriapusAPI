using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries;

public class GetAllKingdomsQuery : IRequest<ApiResponse<IEnumerable<KingdomDto>>>
{
}