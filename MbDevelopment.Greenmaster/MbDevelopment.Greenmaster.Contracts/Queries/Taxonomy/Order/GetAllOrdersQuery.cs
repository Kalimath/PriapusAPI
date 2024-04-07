using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Order;

public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>
{
}