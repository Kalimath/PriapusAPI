using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Phylum;

public class GetPhylumByIdQuery(string id) : IRequest<PhylumDto>
{
    public string Id { get; set; } = id;
}