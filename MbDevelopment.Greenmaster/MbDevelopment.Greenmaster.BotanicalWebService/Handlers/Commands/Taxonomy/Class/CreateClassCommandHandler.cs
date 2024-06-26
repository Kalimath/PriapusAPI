using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Class;

public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, ClassDto>
{
    private readonly IRepository<TaxonClass> _classRepo;
    private readonly IRepository<TaxonPhylum> _phylumRepo;
    private readonly IHashids _hashids;
    private readonly ClassTaxonDtoMapper _taxonDtoMapper;

    public CreateClassCommandHandler(IRepository<TaxonClass> classRepo, IRepository<TaxonPhylum> phylumRepo, IHashids hashids)
    {
        _classRepo = classRepo ?? throw new ArgumentNullException(nameof(classRepo));
        _phylumRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = new ClassTaxonDtoMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }
    
    public async Task<ClassDto> Handle(CreateClassCommand request, CancellationToken cancellationToken)
    {
        var decodedPhylumId = _hashids.DecodeSingle(request.PhylumId);
        var requestedPhylum = await _phylumRepo.GetAsync(x => x.Id == decodedPhylumId, cancellationToken);
        if (requestedPhylum == null) throw new ValidationException("Phylum not found");
        var newClass = new TaxonClass()
        {
            LatinName = request.Name,
            Description = request.Description,
            Phylum = requestedPhylum
        };
        _classRepo.Add(newClass);
        await _classRepo.SaveChangesAsync(cancellationToken);
        var createdItem = _classRepo.Query(x => x.LatinName == request.Name && x.Description == request.Description).FirstOrDefault();
        if (createdItem == null) throw new Exception("Failed to get created class");
        return _taxonDtoMapper.ToDto(createdItem)!;
    }
}