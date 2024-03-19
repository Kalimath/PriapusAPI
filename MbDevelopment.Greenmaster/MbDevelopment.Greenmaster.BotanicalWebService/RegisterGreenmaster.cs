using System.Reflection;
using FluentValidation;
using MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Validation;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService;

public static class RegisterGreenmaster
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
    
    public static IServiceCollection AddCqrs(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}