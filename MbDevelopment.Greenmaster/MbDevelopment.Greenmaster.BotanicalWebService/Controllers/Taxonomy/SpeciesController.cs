using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Base;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Species;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Species;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(SpeciesApi.Route)]
public class SpeciesController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SpeciesDto), 200)]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        return await ExecuteAsync(new GetSpeciesByIdQuery(id));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BasicTaxonDto>), 200)]
    public async Task<IActionResult> GetAll()
    {
        return await ExecuteAsync(new GetAllSpeciesQuery());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSpeciesCommand command)
    {
        return await ExecutePost(command);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSpeciesCommand command)
    {
        return await ExecutePut(command);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteSpeciesCommand command)
    {
        return await ExecuteDelete(command);
    }
}