using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Species;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Species;

public class GetSpeciesByIdQueryHandler : IRequestHandler<GetSpeciesByIdQuery, SpeciesDto>
{
    private readonly IRepository<TaxonSpecies> _speciesRepo;
    private readonly IRepository<TaxonGenus> _genusRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonSpecies, SpeciesDto> _speciesMapper;

    public GetSpeciesByIdQueryHandler(IRepository<TaxonSpecies> speciesRepo, IRepository<TaxonGenus> genusRepo, ITaxonDtoMapper<TaxonSpecies, SpeciesDto> speciesMapper, IHashids hashids)
    {
        _speciesRepo = speciesRepo ?? throw new ArgumentNullException(nameof(speciesRepo));
        _genusRepo = genusRepo ?? throw new ArgumentNullException(nameof(genusRepo));
        _speciesMapper = speciesMapper ?? throw new ArgumentNullException(nameof(speciesMapper));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<SpeciesDto> Handle(GetSpeciesByIdQuery request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        
        var requestedSpecies = await _speciesRepo.GetAsync(x => x.Id == decodedId, cancellationToken);
        if (requestedSpecies == null) throw new KeyNotFoundException($"Species with id: {request.Id} not found");
        
        requestedSpecies.Genus = (await _genusRepo.GetAsync(x => x.Id == requestedSpecies.GenusId, cancellationToken))!;
        
        return _speciesMapper.ToDto(requestedSpecies)!;
    }
}