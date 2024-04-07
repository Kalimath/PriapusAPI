using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Phylum;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Phylum;

public class GetPhylumByIdQueryHandler : IRequestHandler<GetPhylumByIdQuery, PhylumDto>
{
    private readonly IRepository<TaxonPhylum> _phylumRepo;
    private readonly IRepository<TaxonKingdom> _kingdomRepo;
    private readonly IHashids _hashids;
    private readonly PhylumMapper _phylumMapper;
    
    public GetPhylumByIdQueryHandler(IRepository<TaxonPhylum> phylumRepo, IRepository<TaxonKingdom> kingdomRepo, IHashids hashids)
    {
        _phylumRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _kingdomRepo = kingdomRepo ?? throw new ArgumentNullException(nameof(kingdomRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _phylumMapper = new PhylumMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }
    
    public async Task<PhylumDto> Handle(GetPhylumByIdQuery request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        
        var phylum = await _phylumRepo.GetAsync(x => x.Id == decodedId, cancellationToken);
        if (phylum == null) throw new KeyNotFoundException($"Phylum with id: {request.Id} not found");
        
        phylum.Kingdom = (await _kingdomRepo.GetAsync(x => x.Id == phylum.KingdomId, cancellationToken))!;
        
        return _phylumMapper.ToDto(phylum)!;
    }
}