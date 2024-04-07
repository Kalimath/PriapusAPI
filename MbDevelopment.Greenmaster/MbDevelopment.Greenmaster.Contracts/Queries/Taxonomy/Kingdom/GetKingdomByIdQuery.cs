using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Kingdom;

public class GetKingdomByIdQuery : QueryBase<KingdomDto>
{
    public string Id { get; }
    
    public GetKingdomByIdQuery(string id)
    {
        Id = id;
    }

}