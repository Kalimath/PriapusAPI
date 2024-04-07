using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;

public class CreateOrderCommand : IRequest<OrderDto>
{
    public string Name { get; }
    public string Description { get; }
    public string ClassId { get; }

    public CreateOrderCommand(string name, string description, string classId)
    {
        Name = name;
        Description = description;
        ClassId = classId;
    }
}