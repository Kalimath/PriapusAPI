using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Family;

public class DeleteFamilyCommand : IRequest<FamilyDto>
{
    public string Id { get; }
    
    public DeleteFamilyCommand(string id)
    {
        Id = id;
    }
}