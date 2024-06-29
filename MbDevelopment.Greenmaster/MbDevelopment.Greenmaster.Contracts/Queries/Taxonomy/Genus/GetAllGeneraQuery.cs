using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Genus;

public class GetAllGeneraQuery : IRequest<IEnumerable<BasicTaxonDto>>
{
}