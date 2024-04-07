using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;

public class UpdatePhylumCommand : IRequest<PhylumDto>
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string KingdomId { get; }

    public UpdatePhylumCommand(string id, string name, string description, string kingdomId)
    {
        Id = id;
        Name = name;
        Description = description;
        KingdomId = kingdomId;
    }
}