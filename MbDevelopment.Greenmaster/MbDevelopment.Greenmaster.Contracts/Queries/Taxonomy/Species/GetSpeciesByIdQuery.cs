using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Species;

public class GetSpeciesByIdQuery : IRequest<SpeciesDto>
{
    public string Id { get; }

    public GetSpeciesByIdQuery(string id)
    {
        Id = id;
    }
}