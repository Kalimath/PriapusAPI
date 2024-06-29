using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MbDevelopment.Greenmaster.Integration.Tests;

public static class ServiceRegistration
{
    public static void RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext and repository
        services.AddScoped<DbContext>();
        services.AddScoped<IIntegerationTestRepository, IntegerationTestRepository>();

        // Additional service registrations for data access layer
        // ...
    }

    public static void RegisterBusinessServices(this IServiceCollection services)
    {
        // Register business services
        // ...
    }
}

public class IntegerationTestRepository : IIntegerationTestRepository
{
}

public interface IIntegerationTestRepository
{
}