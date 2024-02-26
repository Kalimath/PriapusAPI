using MbDevelopment.Greenmaster.BotanicalWebService.Controllers;
using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Tests.Controllers.GenusControllerTests;

public class GetByIdShould
{
    private readonly Genus _someGenus;
    private readonly GenusController _controller;
    private readonly IGenusQueryService _queryService;

    public GetByIdShould()
    {
        _queryService = Substitute.For<IGenusQueryService>();
        _controller = new GenusController(_queryService);
        _someGenus = new Genus { Id = 1, LatinName = "Genus 1" , Description = "Description 1" };
    }

    [Fact]
    public async Task ReturnOkObjectResult()
    {
        // Arrange

        // Act
        var response = await _controller.GetById(1);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }

    [Fact]
    public async Task CallQueryService_WithId_FromRequest()
    {
        var response = await _controller.GetById(1);
        
        await _queryService.Received(1).GetById(1);
    }

    [Fact]
    public async Task ReturnGenus_FromQueryService()
    {
        // Arrange
        _queryService.GetById(1).Returns(_someGenus);

        // Act
        var response = (OkObjectResult)await _controller.GetById(1);

        // Assert
        Assert.Equal(_someGenus, response.Value);
    }
}