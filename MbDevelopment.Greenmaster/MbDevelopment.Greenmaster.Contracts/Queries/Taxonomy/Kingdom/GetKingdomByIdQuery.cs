using MbDevelopment.Greenmaster.Contracts.Dtos;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Kingdom;

public class GetKingdomByIdQuery : QueryBase<KingdomDto>
{
    public string Id { get; }
    
    public GetKingdomByIdQuery(string id)
    {
        Id = id;
    }

}