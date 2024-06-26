using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Base;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(FamilyApi.Route)]
public class GenusController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        return await ExecuteAsync(new GetGenusByIdQuery(id));
        //TODO: add validator and implement handler and taxonDtoMapper
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return await ExecuteAsync(new GetAllGeneraQuery());
        //TODO: add validator and implement handler
    }
    
    //TODO: check for existence of item at creation and update
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        return await ExecutePost(command);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command)
    {
        return await ExecutePut(command);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteOrderCommand command)
    {
        return await ExecuteDelete(command);
    }
}

public class GetAllGeneraQuery : IRequest<IEnumerable<GenusDto>>
{
}

public class GetGenusByIdQuery : IRequest<GenusDto>
{
    public string Id { get; }

    public GetGenusByIdQuery(string id)
    {
        Id = id;
    }
}