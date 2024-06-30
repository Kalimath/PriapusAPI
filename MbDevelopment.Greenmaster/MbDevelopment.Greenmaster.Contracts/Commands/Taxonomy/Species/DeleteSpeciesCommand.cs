using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Species;

public class DeleteSpeciesCommand(string id) : IRequest<SpeciesDto>
{
    public string Id { get; } = id;
}