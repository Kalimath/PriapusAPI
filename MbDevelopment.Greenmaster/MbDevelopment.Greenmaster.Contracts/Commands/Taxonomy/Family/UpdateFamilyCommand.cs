using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Family;

public class UpdateFamilyCommand : IRequest<FamilyDto>
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string OrderId { get; }

    public UpdateFamilyCommand(string id, string name, string description, string orderId)
    {
        Id = id;
        Name = name;
        Description = description;
        OrderId = orderId;
    }
}