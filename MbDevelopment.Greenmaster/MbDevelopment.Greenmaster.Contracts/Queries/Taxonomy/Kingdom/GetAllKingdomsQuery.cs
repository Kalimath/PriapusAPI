using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Kingdom;

public class GetAllKingdomsQuery : IRequest<IEnumerable<KingdomDto>>
{
}