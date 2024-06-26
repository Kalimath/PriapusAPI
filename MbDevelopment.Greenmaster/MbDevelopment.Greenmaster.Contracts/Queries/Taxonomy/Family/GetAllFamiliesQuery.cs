using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Family;

public class GetAllFamiliesQuery : IRequest<IEnumerable<BasicTaxonDto>>
{
    
}