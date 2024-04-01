using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Class;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Class;

public class GetAllClassesQueryHandler : IRequestHandler<GetAllClassesQuery, IEnumerable<ClassDto>>
{
    private readonly IRepository<TaxonClass> _repository;
    private readonly ClassMapper _classMapper;

    public GetAllClassesQueryHandler(IRepository<TaxonClass> repository, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _classMapper = new ClassMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<IEnumerable<ClassDto>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.All().Include(c => c.Phylum).Select(c => _classMapper.ToDto(c)).ToListAsync(cancellationToken))!;
    }
}