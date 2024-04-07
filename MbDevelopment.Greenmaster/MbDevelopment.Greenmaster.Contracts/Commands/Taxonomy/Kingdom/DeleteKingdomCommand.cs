using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;

public class DeleteKingdomCommand : IRequest<KingdomDto>
{
    public string Id { get; }
    
    public DeleteKingdomCommand(string id)
    {
        Id = id;
    }
}