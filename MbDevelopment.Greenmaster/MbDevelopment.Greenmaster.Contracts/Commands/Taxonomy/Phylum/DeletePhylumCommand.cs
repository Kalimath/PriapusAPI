using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;

public class DeletePhylumCommand : IRequest<PhylumDto>
{
    public string Id { get; }
    
    public DeletePhylumCommand(string id)
    {
        Id = id;
    }
}