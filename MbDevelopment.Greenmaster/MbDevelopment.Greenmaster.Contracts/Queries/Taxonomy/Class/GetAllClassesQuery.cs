using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Class;

public class GetAllClassesQuery : IRequest<IEnumerable<BasicTaxonDto>>
{
}