using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Phylum;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Phylum;

public class GetAllPhylaQueryHandler : IRequestHandler<GetAllPhylaQuery, IEnumerable<PhylumDto>>
{
    private readonly IRepository<TaxonPhylum> _repository;
    private readonly PhylumMapper _phylumMapper;

    public GetAllPhylaQueryHandler(IRepository<TaxonPhylum> repository, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _phylumMapper = new PhylumMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<IEnumerable<PhylumDto>> Handle(GetAllPhylaQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.All().Include(phylum => phylum.Kingdom).Select(phylum => _phylumMapper.ToDto(phylum)).ToListAsync(cancellationToken))!;
    }
}