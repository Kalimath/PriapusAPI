using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Order;

public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public string Id { get; }

    public GetOrderByIdQuery(string id)
    {
        Id = id;
    }
}