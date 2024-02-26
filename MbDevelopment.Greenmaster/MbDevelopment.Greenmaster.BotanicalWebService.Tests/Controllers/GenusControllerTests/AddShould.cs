using MbDevelopment.Greenmaster.Contracts.WebApi.Dto;
using MbDevelopment.Greenmaster.Core.Botanical;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Tests.Controllers.GenusControllerTests;

public class AddShould : GenusControllerTestBase
{
    private readonly AddGenusDto _someAddGenusDto;

    public AddShould()
    {
        _someAddGenusDto = new AddGenusDto()
        {
            LatinName = SomeGenus.LatinName,
            Description = SomeGenus.Description
        };
    }

    [Fact]
    public async Task ReturnAcceptedResult_WhenRequestValid()
    {
        var response = await Controller.Add(_someAddGenusDto);

        Assert.IsType<AcceptedResult>(response);
    }

    [Fact]
    public async Task ReturnBadRequestResult_WhenRequestInvalid()
    {
        var invalidDto = new AddGenusDto();
        
        var response = await Controller.Add(invalidDto);

        Assert.IsType<BadRequestObjectResult>(response);
    }

    [Fact]
    public async Task CallGenusQueryService_WithCorrectData_WhenRequestValid()
    {
        var response = await Controller.Add(_someAddGenusDto);

        await QueryService.Received(1).Add(Arg.Is<Genus>(
                genus => genus.LatinName == _someAddGenusDto.LatinName && 
                         genus.Description == _someAddGenusDto.Description));
    }
}
