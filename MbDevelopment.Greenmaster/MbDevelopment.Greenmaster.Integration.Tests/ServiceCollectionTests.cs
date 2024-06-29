using MbDevelopment.Greenmaster.BotanicalWebService;
using Microsoft.Extensions.DependencyInjection;

namespace MbDevelopment.Greenmaster.Integration.Tests;

public class ServiceCollectionTests
{
    [Fact(Skip = "Integration tests not working yet")]
    public void RegisterDataServices_ShouldRegisterIILoveDotNetRepository()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
            
        // Act
        serviceCollection.AddValidation();
        serviceCollection.AddCqrs();
        serviceCollection.AddRepositories();
        serviceCollection.AddMappers();
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
            
        // Assert
        Assert.NotNull(serviceProvider);
    }
}