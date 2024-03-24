using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;

public class DeleteKingdomCommand : IRequest<KingdomDto>
{
    public string Id { get; set; }
}