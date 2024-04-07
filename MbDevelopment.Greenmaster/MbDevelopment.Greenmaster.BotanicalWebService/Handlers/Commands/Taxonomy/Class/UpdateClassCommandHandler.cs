using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Class;

public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, ClassDto>
{
    private readonly IRepository<TaxonClass> _classRepo;
    private readonly IRepository<TaxonPhylum> _phylumRepo;
    private readonly IHashids _hashids;
    private readonly ClassMapper _mapper;
    
    public UpdateClassCommandHandler(IRepository<TaxonClass> classRepo, IRepository<TaxonPhylum> phylumRepo, IHashids hashids)
    {
        _classRepo = classRepo ?? throw new ArgumentNullException(nameof(classRepo));
        _phylumRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _mapper = new ClassMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }
    
    public async Task<ClassDto> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
    {
        var rawClassId = _hashids.DecodeSingle(request.Id);
        var rawPhylumId = _hashids.DecodeSingle(request.PhylumId);
       
        var requestedClass = await _classRepo.GetAsync(k => k.Id == rawClassId, cancellationToken);
        if (requestedClass == null) throw new ValidationException($"Class with id {request.Id} not found");
       
        var requestedPhylum = await _phylumRepo.GetAsync(k => k.Id == rawPhylumId, cancellationToken);
        if (requestedPhylum == null) throw new ValidationException($"Phylum with id {request.PhylumId}");
       
        UpdateModel(requestedClass, request, requestedPhylum);

        _classRepo.Update(requestedClass);
        await _classRepo.SaveChangesAsync(cancellationToken);
       
        return _mapper.ToDto(requestedClass)!;
    }

    private static void UpdateModel(TaxonClass original, UpdateClassCommand request, TaxonPhylum phylum)
    {
        original.LatinName = request.Name;
        original.Description = request.Description;
        original.PhylumId = phylum.Id;
        original.Phylum = phylum;
    }
}