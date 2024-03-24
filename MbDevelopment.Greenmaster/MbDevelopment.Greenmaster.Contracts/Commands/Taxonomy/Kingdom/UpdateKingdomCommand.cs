using MbDevelopment.Greenmaster.Contracts.Dtos;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;

public class UpdateKingdomCommand : CommandBase<KingdomDto>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}