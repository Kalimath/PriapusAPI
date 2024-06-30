using System.Net;
using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Base;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Kingdom;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(KingdomApi.Route)]
[ApiController]
public class KingdomController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(KingdomDto), 200)]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return BadRequest("id is required");
        return await ExecuteAsync(new GetKingdomByIdQuery(id));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BasicTaxonDto>), 200)]
    public async Task<IActionResult> GetAll()
    {
        return await ExecuteAsync(new GetAllKingdomsQuery());
    }
    
    //TODO: Implement GET Related
    //TODO: check for existence of item at creation and update

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateKingdomCommand command)
    {
        if (command == null) return BadRequest("Command cannot be null.");
        return await ExecutePost(command, HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateKingdomCommand command)
    {
        if (command == null) return BadRequest("Command cannot be null.");
        return await ExecutePut(command);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteKingdomCommand command)
    {
        if (command == null) return BadRequest("Command cannot be null.");
        return await ExecutePut(command);
    }
}