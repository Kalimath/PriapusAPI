using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;

public class CreateClassCommand : IRequest<ClassDto>
{
    public string Name { get; }
    public string Description { get; }
    public string PhylumId { get; }

    public CreateClassCommand(string name, string description, string phylumId)
    {
        Name = name;
        Description = description;
        PhylumId = phylumId;
    }
}