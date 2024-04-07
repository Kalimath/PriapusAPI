using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Phylum;

public class GetPhylumByIdQuery : IRequest<PhylumDto>
{
    public string Id { get; }
    
    public GetPhylumByIdQuery(string id)
    {
        Id = id;
    }

}