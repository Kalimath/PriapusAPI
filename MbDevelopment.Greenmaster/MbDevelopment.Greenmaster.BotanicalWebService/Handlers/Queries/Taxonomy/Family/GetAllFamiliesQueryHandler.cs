using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Family;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Family;

public class GetAllFamiliesQueryHandler : IRequestHandler<GetAllFamiliesQuery, IEnumerable<BasicTaxonDto>>
{
    private readonly IRepository<TaxonFamily> _repository;
    private readonly ITaxonDtoMapper<TaxonFamily, FamilyDto> _classTaxonDtoMapper;

    public GetAllFamiliesQueryHandler(IRepository<TaxonFamily> repository, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _classTaxonDtoMapper = new FamilyTaxonDtoMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }
    public async Task<IEnumerable<BasicTaxonDto>> Handle(GetAllFamiliesQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.All().Select(c => _classTaxonDtoMapper.ToBasicDto(c)).ToListAsync(cancellationToken))!;
    }
}