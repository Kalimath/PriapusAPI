using MbDevelopment.Greenmaster.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers;


[ApiController()]
public class GenusController : ControllerBase
{
   private readonly IGenusQueryService _queryService;

   public GenusController(IGenusQueryService queryService)
   {
      _queryService = queryService ?? throw new ArgumentNullException(nameof(queryService));
   }

   [HttpPost("/")]
   public async Task<IActionResult> GetById([FromQuery] int id)
   {
      var foundGenus = await _queryService.GetById(id);
      
      return new OkObjectResult(foundGenus);
   }
}