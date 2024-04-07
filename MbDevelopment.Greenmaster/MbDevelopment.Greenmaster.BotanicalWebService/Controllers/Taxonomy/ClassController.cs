using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Base;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Class;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(ClassApi.Route)]
public class ClassController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        return await ExecuteAsync(new GetClassByIdQuery(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return await ExecuteAsync(new GetAllClassesQuery());
    }
    
    //TODO: Implement GET Related
    //TODO: check for existence of item at creation and update
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClassCommand command)
    {
        return await ExecutePost(command);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClassCommand command)
    {
        return await ExecutePut(command);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteClassCommand command)
    {
        return await ExecuteDelete(command);
    }
}