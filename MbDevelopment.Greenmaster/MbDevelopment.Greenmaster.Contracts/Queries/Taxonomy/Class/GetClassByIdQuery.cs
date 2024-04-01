using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Class;

public class GetClassByIdQuery(string id) : IRequest<ClassDto>
{
    public string Id { get; set; } = id;
}