using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS;

public class GetKingdomByIdQuery(Guid id) : IRequest<KingdomDto>
{
    public Guid Id { get; set; } = id;
}