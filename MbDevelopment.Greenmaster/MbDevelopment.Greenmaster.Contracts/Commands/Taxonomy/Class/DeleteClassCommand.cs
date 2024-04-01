using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;

public class DeleteClassCommand : IRequest<ClassDto>
{
    public string Id { get; set; }
}