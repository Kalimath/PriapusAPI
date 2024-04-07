using MbDevelopment.Greenmaster.Contracts.Dtos;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;

public class UpdateKingdomCommand : CommandBase<KingdomDto>
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }

    public UpdateKingdomCommand(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}