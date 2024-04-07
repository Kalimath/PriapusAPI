using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;

public class UpdateOrderCommand : IRequest<OrderDto>
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string ClassId { get; }

    public UpdateOrderCommand(string id, string name, string description, string classId)
    {
        Id = id;
        Name = name;
        Description = description;
        ClassId = classId;
    }
}