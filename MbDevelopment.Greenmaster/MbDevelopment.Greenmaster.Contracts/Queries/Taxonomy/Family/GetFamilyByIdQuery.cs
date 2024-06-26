using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Family;

public class GetFamilyByIdQuery : IRequest<FamilyDto>
{
    public string Id { get; set; }
    
    public GetFamilyByIdQuery(string id) => Id = id;
}