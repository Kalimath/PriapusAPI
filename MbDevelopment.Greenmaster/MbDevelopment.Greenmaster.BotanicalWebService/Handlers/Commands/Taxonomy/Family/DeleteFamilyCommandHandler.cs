using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Family;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Family;

public class DeleteFamilyCommandHandler : IRequestHandler<DeleteFamilyCommand, FamilyDto>
{
    private readonly IRepository<TaxonFamily> _familyRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonFamily, FamilyDto> _taxonDtoMapper;

    public DeleteFamilyCommandHandler(IRepository<TaxonFamily> familyRepo, IHashids hashids)
    {
        _familyRepo = familyRepo ?? throw new ArgumentNullException(nameof(familyRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = new FamilyTaxonDtoMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<FamilyDto> Handle(DeleteFamilyCommand request, CancellationToken cancellationToken)
    {
        //TODO: all underlying types are orphaned and need to be deleted
        var decodedId = _hashids.DecodeSingle(request.Id);
        var requested = await _familyRepo.GetAsync(family => family.Id == decodedId, cancellationToken);
        if (requested == null) throw new KeyNotFoundException($"Family with id: {decodedId} not found");
        
        _familyRepo.Delete(requested);
        await _familyRepo.SaveChangesAsync(cancellationToken);
        return _taxonDtoMapper.ToDto(requested)!;
    }
}