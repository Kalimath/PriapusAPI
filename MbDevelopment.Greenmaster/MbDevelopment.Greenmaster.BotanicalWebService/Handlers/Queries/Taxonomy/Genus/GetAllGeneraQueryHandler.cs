using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Genus;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Genus;

public class GetAllGeneraQueryHandler : IRequestHandler<GetAllGeneraQuery, IEnumerable<BasicTaxonDto>>
{
    private readonly IRepository<TaxonGenus> _genusRepo;
    private readonly ITaxonDtoMapper<TaxonGenus, GenusDto> _genusMapper;

    public GetAllGeneraQueryHandler(IRepository<TaxonGenus> repository, ITaxonDtoMapper<TaxonGenus, GenusDto> genusMapper)
    {
        _genusRepo = repository?? throw new ArgumentNullException(nameof(repository));
        _genusMapper = genusMapper?? throw new ArgumentNullException(nameof(genusMapper));
    }
    
    public async Task<IEnumerable<BasicTaxonDto>> Handle(GetAllGeneraQuery request, CancellationToken cancellationToken)
    {
        return (await _genusRepo.All().Select(c => _genusMapper.ToBasicDto(c)).ToListAsync(cancellationToken))!;
    }
}