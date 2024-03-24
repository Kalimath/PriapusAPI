using MbDevelopment.Greenmaster.Contracts.Dtos;

namespace MbDevelopment.Greenmaster.Contracts.Queries.TaxonKingdom;

public class GetKingdomByIdQuery(string id) : QueryBase<KingdomDto>
{
    public string Id { get; set; } = id;
}