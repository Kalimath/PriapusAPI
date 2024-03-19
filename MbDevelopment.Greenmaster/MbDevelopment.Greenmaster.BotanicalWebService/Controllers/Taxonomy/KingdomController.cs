using MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Commands;
using MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries;
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

    public KingdomController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<KingdomDto>> Get([FromRoute] string id)
    {
        //TODO: validation pipeline
        var query = new GetKingdomByIdQuery(id);
        var result = await _mediator.Send(query);
        
        return result;
    }

    [HttpGet]
    public async Task<ApiResponse<IEnumerable<KingdomDto>>> GetAll()
    {
        var query = new GetAllKingdomsQuery();
        var result = await _mediator.Send(query);
        return result;
    }

    [HttpPost]
    public async Task<ApiResponse<KingdomDto>> Create([FromBody] CreateKingdomRequest request)
    {
        var query = new CreateKingdomCommand(request);
        var result = await _mediator.Send(query);
        return result;
    }
}