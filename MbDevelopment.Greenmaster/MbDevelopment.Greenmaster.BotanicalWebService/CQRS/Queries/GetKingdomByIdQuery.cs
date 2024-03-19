using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries;

public class GetKingdomByIdQuery(int id) : IRequest<KingdomDto>
{
    public int Id { get; set; } = id;
}