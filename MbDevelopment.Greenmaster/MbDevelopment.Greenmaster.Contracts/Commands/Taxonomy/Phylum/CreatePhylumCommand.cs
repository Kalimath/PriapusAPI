using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;

public class CreatePhylumCommand : IRequest<PhylumDto>
{
    public string Name { get; }
    public string Description { get; }
    public string KingdomId { get; }

    public CreatePhylumCommand(string name, string description, string kingdomId)
    {
        Name = name;
        Description = description;
        KingdomId = kingdomId;
    }
}