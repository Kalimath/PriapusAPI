using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;

public class DeleteGenusCommand : IRequest<GenusDto>
{
    public string Id { get; }
    
    public DeleteGenusCommand(string id)
    {
        Id = id;
    }
}