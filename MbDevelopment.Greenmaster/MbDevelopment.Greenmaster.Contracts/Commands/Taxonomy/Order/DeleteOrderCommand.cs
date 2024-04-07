using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;

public class DeleteOrderCommand : IRequest<OrderDto>
{
    public string Id { get; }
    
    public DeleteOrderCommand(string id)
    {
        Id = id;
    }
}