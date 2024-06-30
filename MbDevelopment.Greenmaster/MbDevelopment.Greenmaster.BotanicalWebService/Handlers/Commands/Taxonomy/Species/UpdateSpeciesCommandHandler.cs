using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Species;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Species;

public class UpdateSpeciesCommandHandler : IRequestHandler<UpdateSpeciesCommand, SpeciesDto>
{
    private readonly IRepository<TaxonSpecies> _speciesRepo;
    private readonly IRepository<TaxonGenus> _genusRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonSpecies, SpeciesDto> _speciesMapper;
    
    public UpdateSpeciesCommandHandler(IRepository<TaxonSpecies> speciesRepo, IRepository<TaxonGenus> genusRepo, 
                                        ITaxonDtoMapper<TaxonSpecies, SpeciesDto> speciesMapper, IHashids hashids)
    {
        _speciesRepo = speciesRepo?? throw new ArgumentNullException(nameof(speciesRepo));
        _genusRepo = genusRepo?? throw new ArgumentNullException(nameof(genusRepo));
        _speciesMapper = speciesMapper ?? throw new ArgumentNullException(nameof(speciesMapper));
        _hashids = hashids?? throw new ArgumentNullException(nameof(hashids));
    }
    public async Task<SpeciesDto> Handle(UpdateSpeciesCommand request, CancellationToken cancellationToken)
    {
        var decodedSpeciesId = _hashids.DecodeSingle(request.Id);
        var decodedGenusId = _hashids.DecodeSingle(request.GenusId);
        
        var requestedSpecies = await _speciesRepo.GetAsync(species => species.Id == decodedSpeciesId, cancellationToken);
        if (requestedSpecies == null) throw new ValidationException($"Species with id {request.Id} not found");
        
        var requestedGenus = await _genusRepo.GetAsync(genus => genus.Id == decodedGenusId, cancellationToken);
        if (requestedGenus == null) throw new ValidationException($"Genus with id {request.GenusId} not found");
        
        UpdateModel(requestedSpecies, request, requestedGenus);
        
        _speciesRepo.Update(requestedSpecies);
        await _speciesRepo.SaveChangesAsync(cancellationToken);
        
        return _speciesMapper.ToDto(requestedSpecies)!;
    }

    private static void UpdateModel(TaxonSpecies original, UpdateSpeciesCommand request, TaxonGenus requestedGenus)
    {
        original.GenusId = requestedGenus.Id;
        original.Genus = requestedGenus;
        original.LatinName = request.Name;
        original.Description = request.Description;
        original.CommonName = request.CommonName;
        original.TrademarkName = request.TrademarkName;
        original.Cultivar = request.Cultivar;
        original.ImageUrl = request.ImageUrl;
    }
}