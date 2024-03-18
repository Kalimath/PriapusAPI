using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[Route(KingdomApi.Route)]
[ApiController]
public class KingdomController : ControllerBase
{
    [HttpGet("/{id:guid}")]
    public async Task<ActionResult<KingdomDto>> GetKingdom(Guid id)
    {
        return await Task.FromResult(new KingdomDto(){Id = id});
    }
}