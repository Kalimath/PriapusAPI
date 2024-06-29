using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Genus;

public class GetGenusByIdQuery : IRequest<GenusDto>
{
    public string Id { get; }

    public GetGenusByIdQuery(string id)
    {
        Id = id;
    }
}