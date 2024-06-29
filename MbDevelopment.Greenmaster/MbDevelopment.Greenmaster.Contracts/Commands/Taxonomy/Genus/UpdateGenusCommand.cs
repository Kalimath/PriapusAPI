using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;

public class UpdateGenusCommand : IRequest<GenusDto>
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string FamilyId { get; }

    public UpdateGenusCommand(string id, string name, string description, string familyId)
    {
        Id = id;
        Name = name;
        Description = description;
        FamilyId = familyId;
    }
}