using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Class;

public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, ClassDto>
{
    private readonly IRepository<TaxonClass> _classRepo;
    private readonly IHashids _hashids;
    private readonly ClassMapper _mapper;

    public DeleteClassCommandHandler(IRepository<TaxonClass> phylumRepo, IHashids hashids)
    {
        _classRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _mapper = new ClassMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<ClassDto> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        var requestedClass = await _classRepo.GetAsync(phylum => phylum.Id == decodedId, cancellationToken);
        if (requestedClass == null) throw new KeyNotFoundException($"Class with id: {decodedId} not found");
        
        _classRepo.Delete(requestedClass);
        await _classRepo.SaveChangesAsync(cancellationToken);
        return new ClassDto()
        {
            Id = request.Id,
            Name = requestedClass.LatinName,
            Description = requestedClass.Description,
            Phylum = new PhylumDto()
            {
                Id = _hashids.Encode(requestedClass.PhylumId),
                Name = null!,
                Description = null!
            }
        };
    }
}