using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Class;

public class GetClassByIdQuery : IRequest<ClassDto>
{
    public string Id { get; }
    
    public GetClassByIdQuery(string id)
    {
        Id = id;
    }
}