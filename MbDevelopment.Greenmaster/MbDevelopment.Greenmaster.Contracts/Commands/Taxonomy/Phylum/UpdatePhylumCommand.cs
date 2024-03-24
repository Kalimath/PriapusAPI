using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;

public class UpdatePhylumCommand : IRequest<PhylumDto>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string KingdomId { get; set; }
}