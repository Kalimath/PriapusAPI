using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;

public class CreateClassCommand : IRequest<ClassDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhylumId { get; set; }
}