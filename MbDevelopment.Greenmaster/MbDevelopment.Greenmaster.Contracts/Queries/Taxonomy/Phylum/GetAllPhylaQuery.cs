using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Phylum;

public class GetAllPhylaQuery : IRequest<IEnumerable<PhylumDto>>
{
}