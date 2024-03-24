using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;

public class CreatePhylumCommand : IRequest<PhylumDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string KingdomId { get; set; }
}