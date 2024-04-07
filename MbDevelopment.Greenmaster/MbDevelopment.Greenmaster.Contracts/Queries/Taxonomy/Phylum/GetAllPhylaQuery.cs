using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Phylum;

public class GetAllPhylaQuery : IRequest<IEnumerable<PhylumDto>>
{
}