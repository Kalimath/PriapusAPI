using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Base;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Genus;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(GenusApi.Route)]
public class GenusController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        return await ExecuteAsync(new GetGenusByIdQuery(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return await ExecuteAsync(new GetAllGeneraQuery());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGenusCommand command)
    {
        return await ExecutePost(command);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGenusCommand command)
    {
        return await ExecutePut(command);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteGenusCommand command)
    {
        return await ExecuteDelete(command);
    }
}