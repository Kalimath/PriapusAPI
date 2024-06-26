using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Class;

public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, ClassDto>
{
    private readonly IRepository<TaxonClass> _classRepo;
    private readonly IHashids _hashids;
    private readonly ClassTaxonDtoMapper _taxonDtoMapper;

    public DeleteClassCommandHandler(IRepository<TaxonClass> phylumRepo, IHashids hashids)
    {
        _classRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = new ClassTaxonDtoMapper(hashids);
    }

    public async Task<ClassDto> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        var requested = await _classRepo.GetAsync(taxonClass => taxonClass.Id == decodedId, cancellationToken);
        if (requested == null) throw new KeyNotFoundException($"Class with id: {decodedId} not found");
        
        _classRepo.Delete(requested);
        await _classRepo.SaveChangesAsync(cancellationToken);
        return _taxonDtoMapper.ToDto(requested)!;
    }
}