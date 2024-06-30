using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Genus;

public class CreateGenusCommandHandler : IRequestHandler<CreateGenusCommand, GenusDto>
{
    private readonly IRepository<TaxonGenus> _genusRepo;
    private readonly IRepository<TaxonFamily> _familyRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonGenus, GenusDto> _genusMapper;

    public CreateGenusCommandHandler(IRepository<TaxonGenus> genusRepo, IRepository<TaxonFamily> familyRepo, 
                                    ITaxonDtoMapper<TaxonGenus, GenusDto> genusMapper, IHashids hashids)
    {
        _genusRepo = genusRepo ?? throw new ArgumentNullException(nameof(genusRepo));
        _familyRepo = familyRepo ?? throw new ArgumentNullException(nameof(familyRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _genusMapper = genusMapper ?? throw new ArgumentNullException(nameof(genusMapper));
    }

    public async Task<GenusDto> Handle(CreateGenusCommand request, CancellationToken cancellationToken)
    {
        if(_genusRepo.Exists(x => x.LatinName == request.Name)) throw new ArgumentException($"Genus with name: {request.Name} already exists");
        var decodedFamilyId = _hashids.DecodeSingle(request.FamilyId);var requestedFamily = await _familyRepo.GetAsync(x => x.Id == decodedFamilyId, cancellationToken);
        if (requestedFamily == null) throw new KeyNotFoundException($"Family with id: {request.FamilyId} not found");
        var genusExistsWithName = await _genusRepo.GetAsync(x => x.LatinName == request.Name, cancellationToken);
        if (genusExistsWithName is not null) return _genusMapper.ToDto(genusExistsWithName)!;
        var newGenus = new TaxonGenus()
        {
            LatinName = request.Name,
            Description = request.Description,
            FamilyId = requestedFamily.Id,
            Family = requestedFamily
        };
        _genusRepo.Add(newGenus);
        await _genusRepo.SaveChangesAsync(cancellationToken);
        var createdItem = _genusRepo.Query(x => x.LatinName == request.Name && x.Description == request.Description).FirstOrDefault();
        if (createdItem == null) throw new Exception("Failed to get created genus");
        return _genusMapper.ToDto(createdItem)!;
    }
}