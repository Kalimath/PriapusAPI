using MbDevelopment.Greenmaster.Core.Botanical;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Tests.Controllers.GenusControllerTests;

public abstract class GenusControllerTestBase
{
    protected readonly Genus SomeGenus;
    protected readonly GenusController Controller;
    protected readonly IGenusQueryService QueryService;

    protected GenusControllerTestBase()
    {
        QueryService = Substitute.For<IGenusQueryService>();
        Controller = new GenusController(QueryService);
        SomeGenus = new Genus { Id = 1, LatinName = "Genus 1" , Description = "Description 1" };
    }
}