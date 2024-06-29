using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;

public class CreateGenusCommand(string name, string description, string familyId) : IRequest<GenusDto>
{
    public string Name { get; } = name;
    public string Description { get; } = description;
    public string FamilyId { get; } = familyId;
}