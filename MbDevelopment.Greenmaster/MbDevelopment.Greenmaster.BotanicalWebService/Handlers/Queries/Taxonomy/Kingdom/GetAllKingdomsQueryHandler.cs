using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Kingdom;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Kingdom;

public class GetAllKingdomsQueryHandler : IRequestHandler<GetAllKingdomsQuery, IEnumerable<KingdomDto>>
{
    private readonly IRepository<TaxonKingdom> _repository;
    private readonly KingdomTaxonDtoMapper _taxonDtoMapper;
    
    public GetAllKingdomsQueryHandler(IRepository<TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _taxonDtoMapper = new KingdomTaxonDtoMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids)); 
    }
    
    public async Task<IEnumerable<KingdomDto>> Handle(GetAllKingdomsQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.All().Select(x => _taxonDtoMapper.ToDto(x)).ToListAsync(cancellationToken))!;
    }
}