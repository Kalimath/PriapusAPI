using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;

public class UpdateClassCommand : IRequest<ClassDto>
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string PhylumId { get; }

    public UpdateClassCommand(string id, string name, string description, string phylumId)
    {
        Id = id;
        Name = name;
        Description = description;
        PhylumId = phylumId;
    }
}