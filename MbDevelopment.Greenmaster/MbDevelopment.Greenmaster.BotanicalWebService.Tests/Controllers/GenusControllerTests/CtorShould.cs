namespace MbDevelopment.Greenmaster.BotanicalWebService.Tests.Controllers.GenusControllerTests;

public class CtorShould
{
    [Fact]
    public void ThrowArgumentNullException_WhenQueryServiceIsNull()
    {
         Assert.Throws<ArgumentNullException>(() => new GenusController(null!));
    }
}