using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.TaxonKingdom;

public class GetAllKingdomsQuery : IRequest<IEnumerable<KingdomDto>>
{
}