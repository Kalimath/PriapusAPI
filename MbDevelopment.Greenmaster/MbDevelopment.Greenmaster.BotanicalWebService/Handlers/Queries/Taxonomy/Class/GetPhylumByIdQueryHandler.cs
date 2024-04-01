using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Class;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Class;

public class GetClassByIdQueryHandler : IRequestHandler<GetClassByIdQuery, ClassDto>
{
    private readonly IRepository<TaxonClass> _classRepo;
    private readonly IRepository<TaxonPhylum> _phylumRepo;
    private readonly IHashids _hashids;
    private readonly ClassMapper _classMapper;
    
    public GetClassByIdQueryHandler(IRepository<TaxonClass> classRepo, IRepository<TaxonPhylum> phylumRepo, IHashids hashids)
    {
        _classRepo = classRepo ?? throw new ArgumentNullException(nameof(classRepo));
        _phylumRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _classMapper = new ClassMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }
    
    public async Task<ClassDto> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        
        var requestedClass = await _classRepo.GetAsync(x => x.Id == decodedId, cancellationToken);
        if (requestedClass == null) throw new KeyNotFoundException($"Class with id: {request.Id} not found");
        
        requestedClass.Phylum = (await _phylumRepo.GetAsync(x => x.Id == requestedClass.PhylumId, cancellationToken))!;
        
        return _classMapper.ToDto(requestedClass)!;
    }
}