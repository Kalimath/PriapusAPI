using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Class;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Class;

public class GetAllClassesQueryHandler : IRequestHandler<GetAllClassesQuery, IEnumerable<BasicTaxonDto>>
{
    private readonly IRepository<TaxonClass> _repository;
    private readonly ClassMapper _classMapper;

    public GetAllClassesQueryHandler(IRepository<TaxonClass> repository, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _classMapper = new ClassMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<IEnumerable<BasicTaxonDto>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.All().Select(c => _classMapper.ToBasicDto(c)).ToListAsync(cancellationToken))!;
    }
}