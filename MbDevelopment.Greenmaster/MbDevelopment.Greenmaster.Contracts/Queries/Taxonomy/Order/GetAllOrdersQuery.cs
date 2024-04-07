using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Order;

public class GetAllOrdersQuery : IRequest<IEnumerable<BasicTaxonDto>>
{
}