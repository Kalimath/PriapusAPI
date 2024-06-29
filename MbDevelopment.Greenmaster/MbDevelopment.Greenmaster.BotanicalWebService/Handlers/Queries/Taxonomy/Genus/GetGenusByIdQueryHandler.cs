using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Genus;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Genus;

public class GetGenusByIdQueryHandler : IRequestHandler<GetGenusByIdQuery, GenusDto>
{
    private readonly IRepository<TaxonGenus> _genusRepo;
    private readonly IRepository<TaxonFamily> _familyRepo;
    private readonly IHashids _hashids;
    private readonly ITaxonDtoMapper<TaxonGenus, GenusDto> _genusMapper;

    public GetGenusByIdQueryHandler(IRepository<TaxonGenus> genusRepo, IRepository<TaxonFamily> familyRepo, ITaxonDtoMapper<TaxonGenus, GenusDto> genusMapper, IHashids hashids)
    {
        _genusRepo = genusRepo ?? throw new ArgumentNullException(nameof(genusRepo));
        _familyRepo = familyRepo ?? throw new ArgumentNullException(nameof(familyRepo));
        _genusMapper = genusMapper ?? throw new ArgumentNullException(nameof(genusMapper));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<GenusDto> Handle(GetGenusByIdQuery request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        
        var requestedGenus = await _genusRepo.GetAsync(x => x.Id == decodedId, cancellationToken);
        if (requestedGenus == null) throw new KeyNotFoundException($"Genus with id: {request.Id} not found");
        
        requestedGenus.Family = (await _familyRepo.GetAsync(x => x.Id == requestedGenus.FamilyId, cancellationToken))!;
        
        return _genusMapper.ToDto(requestedGenus)!;
    }
}