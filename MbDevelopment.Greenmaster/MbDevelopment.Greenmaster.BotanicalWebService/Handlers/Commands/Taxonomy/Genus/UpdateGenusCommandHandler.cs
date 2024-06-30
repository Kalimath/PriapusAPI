using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Genus;

public class UpdateGenusCommandHandler : IRequestHandler<UpdateGenusCommand, GenusDto>
{
    private readonly IRepository<TaxonGenus> _genusRepo;
    private readonly IRepository<TaxonFamily> _familyRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonGenus, GenusDto> _genusMapper;
    
    public UpdateGenusCommandHandler(IRepository<TaxonGenus> genusRepo, IRepository<TaxonFamily> familyRepo, 
                                        ITaxonDtoMapper<TaxonGenus, GenusDto> genusMapper, IHashids hashids)
    {
        _genusRepo = genusRepo?? throw new ArgumentNullException(nameof(genusRepo));
        _familyRepo = familyRepo?? throw new ArgumentNullException(nameof(familyRepo));
        _genusMapper = genusMapper ?? throw new ArgumentNullException(nameof(genusMapper));
        _hashids = hashids?? throw new ArgumentNullException(nameof(hashids));
    }
    public async Task<GenusDto> Handle(UpdateGenusCommand request, CancellationToken cancellationToken)
    {
        var decodedGenusId = _hashids.DecodeSingle(request.Id);
        var decodedFamilyId = _hashids.DecodeSingle(request.FamilyId);
        
        var requestedGenus = await _genusRepo.GetAsync(genus => genus.Id == decodedGenusId, cancellationToken);
        if (requestedGenus == null) throw new ValidationException($"Genus with id {request.Id} not found");
        
        var requestedFamily = await _familyRepo.GetAsync(family => family.Id == decodedFamilyId, cancellationToken);
        if (requestedFamily == null) throw new ValidationException($"Family with id {request.FamilyId} not found");
        
        UpdateModel(requestedGenus, request, requestedFamily);
        
        _genusRepo.Update(requestedGenus);
        await _genusRepo.SaveChangesAsync(cancellationToken);
        
        return _genusMapper.ToDto(requestedGenus)!;
    }

    private static void UpdateModel(TaxonGenus original, UpdateGenusCommand request, TaxonFamily requestedFamily)
    {
        original.LatinName = request.Name;
        original.Description = request.Description;
        original.FamilyId = requestedFamily.Id;
        original.Family = requestedFamily;
    }
}