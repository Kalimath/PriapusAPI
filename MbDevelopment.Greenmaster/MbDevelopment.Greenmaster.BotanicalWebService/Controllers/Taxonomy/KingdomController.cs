using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.CQRS;
using MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Commands;
using MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Api;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(KingdomApi.Route)]
[ApiController]
public class KingdomController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHashids _hashids;

    public KingdomController(IMediator mediator, IHashids hashids)
    {
        _mediator = mediator;
        _hashids = hashids;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<KingdomDto>> Get([FromRoute] string id)
    {
        var rawId = _hashids.Decode(id);
        if (rawId.Length == 0) return NotFound();
        Console.WriteLine("endpoint hit");
        var query = new GetKingdomByIdQuery(rawId.First());
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<KingdomDto>>> GetAll()
    {
        var query = new GetAllKingdomsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ApiResponse<KingdomDto>> Create([FromBody] CreateKingdomRequest request)
    {
        var query = new CreateKingdomCommand(request);
        var result = await _mediator.Send(query);
        return result;
    }
}