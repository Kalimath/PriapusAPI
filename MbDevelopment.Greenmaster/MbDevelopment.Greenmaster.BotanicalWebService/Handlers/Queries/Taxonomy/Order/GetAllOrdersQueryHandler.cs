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
    private readonly IMapper<TaxonOrder, OrderDto> _mapper;
    
    public GetAllOrdersQueryHandler(IRepository<TaxonOrder> repository, IMapper<TaxonOrder, OrderDto> mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 
    }
    
    public async Task<IEnumerable<BasicTaxonDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.All().Select(x => _mapper.ToBasicDto(x)).ToListAsync(cancellationToken))!;
    }
}