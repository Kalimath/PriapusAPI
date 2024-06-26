using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Order;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Queries.Taxonomy.Order;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<BasicTaxonDto>>
{
    private readonly IRepository<TaxonOrder> _repository;
    private readonly ITaxonDtoMapper<TaxonOrder, OrderDto> _taxonDtoMapper;
    
    public GetAllOrdersQueryHandler(IRepository<TaxonOrder> repository, ITaxonDtoMapper<TaxonOrder, OrderDto> taxonDtoMapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _taxonDtoMapper = taxonDtoMapper ?? throw new ArgumentNullException(nameof(taxonDtoMapper)); 
    }
    
    public async Task<IEnumerable<BasicTaxonDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.All().Select(x => _taxonDtoMapper.ToBasicDto(x)).ToListAsync(cancellationToken))!;
    }
}