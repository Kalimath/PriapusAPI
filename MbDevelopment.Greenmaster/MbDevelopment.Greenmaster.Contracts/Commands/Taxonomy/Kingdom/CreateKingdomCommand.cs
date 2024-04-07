using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;

public class CreateKingdomCommand : CommandBase<KingdomDto>
{
    public string Name { get; }
    public string Description { get; }
    
    public CreateKingdomCommand(string name, string description)
    {
        Name = name;
        Description = description;
    }
}