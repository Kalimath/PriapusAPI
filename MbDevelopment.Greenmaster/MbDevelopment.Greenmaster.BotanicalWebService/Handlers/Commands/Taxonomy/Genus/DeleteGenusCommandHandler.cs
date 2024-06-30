using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Genus;

public class DeleteGenusCommandHandler : IRequestHandler<DeleteGenusCommand, GenusDto>
{
    private readonly IRepository<TaxonGenus> _genusRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonGenus, GenusDto> _genusMapper;

    public DeleteGenusCommandHandler(IRepository<TaxonGenus> genusRepo, ITaxonDtoMapper<TaxonGenus, GenusDto> genusMapper, IHashids hashids)
    {
        _genusRepo = genusRepo ?? throw new ArgumentNullException(nameof(genusRepo));
        _genusMapper = genusMapper ?? throw new ArgumentNullException(nameof(genusMapper));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<GenusDto> Handle(DeleteGenusCommand request, CancellationToken cancellationToken)
    {
        //TODO: all underlying types are orphaned and need to be deleted
        var decodedId = _hashids.DecodeSingle(request.Id);
        var requested = await _genusRepo.GetAsync(genus => genus.Id == decodedId, cancellationToken);
        if (requested == null) throw new KeyNotFoundException($"Genus with id: {decodedId} not found");
        
        _genusRepo.Delete(requested);
        await _genusRepo.SaveChangesAsync(cancellationToken);
        return _genusMapper.ToDto(requested)!;
    }
}