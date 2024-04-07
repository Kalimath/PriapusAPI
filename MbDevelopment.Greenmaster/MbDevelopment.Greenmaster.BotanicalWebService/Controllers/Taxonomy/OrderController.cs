using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Base;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Order;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(OrderApi.Route)]
public class OrderController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        return await ExecuteAsync(new GetOrderByIdQuery(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return await ExecuteAsync(new GetAllOrdersQuery());
    }
    
    //TODO: Implement GET Related
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