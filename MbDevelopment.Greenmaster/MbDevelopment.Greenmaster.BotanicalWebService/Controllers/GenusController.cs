using MbDevelopment.Greenmaster.Contracts.WebApi.Dto;
using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using static MbDevelopment.Greenmaster.Core.HelperMethods.ExceptionExtensions;
using static MbDevelopment.Greenmaster.Core.HelperMethods.Validators;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers;

[ApiController()]
public class GenusController(IGenusQueryService queryService) : ControllerBase
{
    private readonly IGenusQueryService _queryService = queryService ?? throw new ArgumentNullException(nameof(queryService));

    [HttpPost("/")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var foundGenus = await _queryService.GetById(id);

        return new OkObjectResult(foundGenus);
    }

    public async Task<IActionResult> Add([FromBody] AddGenusDto requestDto)
    {
        try
        {
            ThrowIfNull(requestDto);
            //TODO: Validate requestDto
            if (string.IsNullOrEmpty(requestDto.LatinName))
            {
                throw new ArgumentException( $"{nameof(requestDto.LatinName)} invalid", nameof(requestDto.LatinName));
            }
            await _queryService.Add(new Genus
            {
                Id = 0,
                LatinName = requestDto.LatinName,
                Description = requestDto.Description ?? "/"
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
        return new AcceptedResult();
    }
}