using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Species;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Species;

public class CreateSpeciesCommandHandler : IRequestHandler<CreateSpeciesCommand, SpeciesDto>
{
    private readonly IRepository<TaxonSpecies> _speciesRepo;
    private readonly IRepository<TaxonGenus> _genusRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonSpecies, SpeciesDto> _speciesMapper;

    public CreateSpeciesCommandHandler(IRepository<TaxonSpecies> speciesRepo, IRepository<TaxonGenus> familyRepo, 
                                    ITaxonDtoMapper<TaxonSpecies, SpeciesDto> speciesMapper, IHashids hashids)
    {
        _speciesRepo = speciesRepo ?? throw new ArgumentNullException(nameof(speciesRepo));
        _genusRepo = familyRepo ?? throw new ArgumentNullException(nameof(familyRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _speciesMapper = speciesMapper ?? throw new ArgumentNullException(nameof(speciesMapper));
    }

    public async Task<SpeciesDto> Handle(CreateSpeciesCommand request, CancellationToken cancellationToken)
    {
        var decodedGenusId = _hashids.DecodeSingle(request.GenusId);
        var requestedGenus = await _genusRepo.GetAsync(x => x.Id == decodedGenusId, cancellationToken);
        if (requestedGenus == null) throw new KeyNotFoundException($"Species with id: {request.GenusId} not found");
        var speciesExistsWithName = await _speciesRepo.GetAsync(x => x.LatinName == request.Name, cancellationToken);
        if (speciesExistsWithName is not null) return _speciesMapper.ToDto(speciesExistsWithName)!;
        var newSpecies = new TaxonSpecies
        {
            GenusId = requestedGenus.Id,
            Genus = requestedGenus,
            LatinName = request.Name,
            Description = request.Description,
            CommonName = request.CommonName,
            TrademarkName = request.TrademarkName!,
            Cultivar = request.Cultivar!,
            ImageUrl = request.ImageUrl,
        };
        _speciesRepo.Add(newSpecies);
        await _speciesRepo.SaveChangesAsync(cancellationToken);
        var createdItem = _speciesRepo.Query(x => x.LatinName == request.Name && x.Description == request.Description).FirstOrDefault();
        if (createdItem == null) throw new Exception("Failed to get created species");
        return _speciesMapper.ToDto(createdItem)!;
    }
}