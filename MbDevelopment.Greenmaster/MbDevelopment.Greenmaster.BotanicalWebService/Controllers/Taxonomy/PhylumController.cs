using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Base;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Phylum;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(PhylumApi.Route)]
public class PhylumController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        return await ExecuteAsync(new GetPhylumByIdQuery(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return await ExecuteAsync(new GetAllPhylaQuery());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePhylumCommand command)
    {
        return await ExecutePost(command);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePhylumCommand command)
    {
        return await ExecutePut(command);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeletePhylumCommand command)
    {
        return await ExecuteDelete(command);
    }
}