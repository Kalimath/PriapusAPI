using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;

public class DeleteClassCommand : IRequest<ClassDto>
{
    public string Id { get; }
    
    public DeleteClassCommand(string id)
    {
        Id = id;
    }
}