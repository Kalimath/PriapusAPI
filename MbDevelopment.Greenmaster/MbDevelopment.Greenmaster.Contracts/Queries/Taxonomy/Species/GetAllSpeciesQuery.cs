using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Species;

public class GetAllSpeciesQuery : IRequest<IEnumerable<BasicTaxonDto>>
{
}