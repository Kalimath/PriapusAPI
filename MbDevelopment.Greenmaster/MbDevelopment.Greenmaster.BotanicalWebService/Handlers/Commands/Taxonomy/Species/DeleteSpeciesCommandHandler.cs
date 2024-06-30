using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Species;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Species;

public class DeleteSpeciesCommandHandler : IRequestHandler<DeleteSpeciesCommand, SpeciesDto>
{
    private readonly IRepository<TaxonSpecies> _genusRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonSpecies, SpeciesDto> _genusMapper;

    public DeleteSpeciesCommandHandler(IRepository<TaxonSpecies> genusRepo, ITaxonDtoMapper<TaxonSpecies, SpeciesDto> genusMapper, IHashids hashids)
    {
        _genusRepo = genusRepo ?? throw new ArgumentNullException(nameof(genusRepo));
        _genusMapper = genusMapper ?? throw new ArgumentNullException(nameof(genusMapper));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<SpeciesDto> Handle(DeleteSpeciesCommand request, CancellationToken cancellationToken)
    {
        //TODO: all underlying types are orphaned and need to be deleted
        var decodedId = _hashids.DecodeSingle(request.Id);
        var requested = await _genusRepo.GetAsync(species => species.Id == decodedId, cancellationToken);
        if (requested == null) throw new KeyNotFoundException($"Species with id: {decodedId} not found");
        
        _genusRepo.Delete(requested);
        await _genusRepo.SaveChangesAsync(cancellationToken);
        return _genusMapper.ToDto(requested)!;
    }
}