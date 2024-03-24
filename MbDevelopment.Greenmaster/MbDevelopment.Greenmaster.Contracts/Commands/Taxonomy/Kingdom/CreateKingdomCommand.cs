using MbDevelopment.Greenmaster.Contracts.Dtos;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;

public class CreateKingdomCommand : CommandBase<KingdomDto>
{
    public string LatinName { get; set; }
    public string Description { get; set; }
}