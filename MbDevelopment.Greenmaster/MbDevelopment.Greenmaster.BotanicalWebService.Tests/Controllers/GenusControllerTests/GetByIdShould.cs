using MbDevelopment.Greenmaster.Core.Botanical;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Tests.Controllers.GenusControllerTests;

public class GetByIdShould : GenusControllerTestBase
{
    [Fact]
    public async Task ReturnOkObjectResult()
    {
        // Arrange

        // Act
        var response = await Controller.GetById(1);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }

    [Fact]
    public async Task CallQueryService_WithId_FromRequest()
    {
        var response = await Controller.GetById(1);
        
        await QueryService.Received(1).GetById(1);
    }

    [Fact]
    public async Task ReturnGenus_FromQueryService()
    {
        // Arrange
        QueryService.GetById(1).Returns(SomeGenus);

        // Act
        var response = (OkObjectResult)await Controller.GetById(1);

        // Assert
        Assert.Equal(SomeGenus, response.Value);
    }
}