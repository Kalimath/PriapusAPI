using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Base;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Family;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Family;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(FamilyApi.Route)]
public class FamilyController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        return await ExecuteAsync(new GetFamilyByIdQuery(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return await ExecuteAsync(new GetAllFamiliesQuery());
    }
    
    //TODO: Implement GET Related
    //TODO: check for existence of item at creation and update
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFamilyCommand command)
    {
        return await ExecutePost(command);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFamilyCommand command)
    {
        return await ExecutePut(command);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteFamilyCommand command)
    {
        return await ExecuteDelete(command);
    }
}