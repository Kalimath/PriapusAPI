using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Family;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Family;

public class GetAllFamiliesQueryHandler : IRequestHandler<GetAllFamiliesQuery, IEnumerable<BasicTaxonDto>>
{
    private readonly IRepository<TaxonFamily> _familyRepo;
    private readonly ITaxonDtoMapper<TaxonFamily, FamilyDto> _familyMapper;

    public GetAllFamiliesQueryHandler(IRepository<TaxonFamily> repository, ITaxonDtoMapper<TaxonFamily, FamilyDto> familyMapper)
    {
        _familyRepo = repository ?? throw new ArgumentNullException(nameof(repository));
        _familyMapper = familyMapper ?? throw new ArgumentNullException(nameof(familyMapper));
    }
    
    public async Task<IEnumerable<BasicTaxonDto>> Handle(GetAllFamiliesQuery request, CancellationToken cancellationToken)
    {
        return (await _familyRepo.All().Select(c => _familyMapper.ToBasicDto(c)).ToListAsync(cancellationToken))!;
    }
}