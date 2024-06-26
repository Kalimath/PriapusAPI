using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Class;

public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, ClassDto>
{
    private readonly IRepository<TaxonClass> _classRepo;
    private readonly IRepository<TaxonPhylum> _phylumRepo;
    private readonly IHashids _hashids;
    private readonly ClassTaxonDtoMapper _taxonDtoMapper;
    
    public UpdateClassCommandHandler(IRepository<TaxonClass> classRepo, IRepository<TaxonPhylum> phylumRepo, IHashids hashids)
    {
        _classRepo = classRepo ?? throw new ArgumentNullException(nameof(classRepo));
        _phylumRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = new ClassTaxonDtoMapper(hashids);
    }
    
    public async Task<ClassDto> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
    {
        var decodedClassId = _hashids.DecodeSingle(request.Id);
        var decodedPhylumId = _hashids.DecodeSingle(request.PhylumId);
       
        var requestedClass = await _classRepo.GetAsync(k => k.Id == decodedClassId, cancellationToken);
        if (requestedClass == null) throw new ValidationException($"Class with id {request.Id} not found");
       
        var requestedPhylum = await _phylumRepo.GetAsync(k => k.Id == decodedPhylumId, cancellationToken);
        if (requestedPhylum == null) throw new ValidationException($"Phylum with id {request.PhylumId}");
       
        UpdateModel(requestedClass, request, requestedPhylum);

        _classRepo.Update(requestedClass);
        await _classRepo.SaveChangesAsync(cancellationToken);
       
        return _taxonDtoMapper.ToDto(requestedClass)!;
    }

    private static void UpdateModel(TaxonClass original, UpdateClassCommand request, TaxonPhylum phylum)
    {
        original.LatinName = request.Name;
        original.Description = request.Description;
        original.PhylumId = phylum.Id;
        original.Phylum = phylum;
    }
}