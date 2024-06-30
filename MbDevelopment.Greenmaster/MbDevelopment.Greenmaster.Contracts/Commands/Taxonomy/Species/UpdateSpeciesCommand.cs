using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Species;

public class UpdateSpeciesCommand(
    string id,
    string name,
    string description,
    string genusId,
    string commonName,
    string imageUrl,
    string? cultivar,
    string? trademarkName) : IRequest<SpeciesDto>
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public string GenusId { get; set; } = genusId;
    public string CommonName { get; set; } = commonName;
    public string? Cultivar { get; set; } = cultivar;
    public string? TrademarkName { get; set;} = trademarkName;
    public string ImageUrl { get; set; } = imageUrl;

}