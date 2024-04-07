using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Kingdom;

public class GetAllKingdomsQuery : IRequest<IEnumerable<KingdomDto>>
{
}