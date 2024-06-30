using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Species;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Species;

public class GetAllSpeciesQueryHandler : IRequestHandler<GetAllSpeciesQuery, IEnumerable<BasicTaxonDto>>
{
    private readonly IRepository<TaxonSpecies> _speciesRepo;
    private readonly ITaxonDtoMapper<TaxonSpecies, SpeciesDto> _speciesMapper;

    public GetAllSpeciesQueryHandler(IRepository<TaxonSpecies> repository, ITaxonDtoMapper<TaxonSpecies, SpeciesDto> speciesMapper)
    {
        _speciesRepo = repository ?? throw new ArgumentNullException(nameof(repository));
        _speciesMapper = speciesMapper ?? throw new ArgumentNullException(nameof(speciesMapper));
    }
    
    public async Task<IEnumerable<BasicTaxonDto>> Handle(GetAllSpeciesQuery request, CancellationToken cancellationToken)
    {
        return (await _speciesRepo.All().Select(c => _speciesMapper.ToBasicDto(c)).ToListAsync(cancellationToken))!;
    }
}