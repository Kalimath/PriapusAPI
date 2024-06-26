using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Family;

public class CreateFamilyCommand : IRequest<FamilyDto>
{
    public string Name { get; }
    public string Description { get; }
    public string OrderId { get; }

    public CreateFamilyCommand(string name, string description, string orderId)
    {
        Name = name;
        Description = description;
        OrderId = orderId;
    }
}