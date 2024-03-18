using MbDevelopment.Greenmaster.BotanicalWebService.CQRS;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Api;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(KingdomApi.Route)]
[ApiController]
public class KingdomController : ControllerBase
{
    private readonly IMediator _mediator;

    public KingdomController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<KingdomDto>> GetKingdom(Guid id)
    {
        Console.WriteLine("endpoint hit");
        var query = new GetKingdomByIdQuery(id);
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<KingdomDto>>> GetKingdoms()
    {
        var query = new GetAllKingdomsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}