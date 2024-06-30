using System.Reflection;
using FluentValidation;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.BotanicalWebService.Validation;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess;
using MbDevelopment.Greenmaster.DataAccess.Base;
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

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<TaxonKingdom>, BotanicalRepository<TaxonKingdom>>();
        services.AddScoped<IRepository<TaxonPhylum>, BotanicalRepository<TaxonPhylum>>();
        services.AddScoped<IRepository<TaxonClass>, BotanicalRepository<TaxonClass>>();
        services.AddScoped<IRepository<TaxonOrder>, BotanicalRepository<TaxonOrder>>();
        services.AddScoped<IRepository<TaxonFamily>, BotanicalRepository<TaxonFamily>>();
        services.AddScoped<IRepository<TaxonGenus>, BotanicalRepository<TaxonGenus>>();
        services.AddScoped<IRepository<TaxonSpecies>, BotanicalRepository<TaxonSpecies>>();
        return services;
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddScoped<ITaxonDtoMapper<TaxonKingdom, KingdomDto>, KingdomTaxonDtoMapper>();
        services.AddScoped<ITaxonDtoMapper<TaxonPhylum, PhylumDto>, PhylumTaxonDtoMapper>();
        services.AddScoped<ITaxonDtoMapper<TaxonClass, ClassDto>, ClassTaxonDtoMapper>();
        services.AddScoped<ITaxonDtoMapper<TaxonOrder, OrderDto>, OrderTaxonDtoMapper>();
        services.AddScoped<ITaxonDtoMapper<TaxonFamily, FamilyDto>, FamilyTaxonDtoMapper>();
        services.AddScoped<ITaxonDtoMapper<TaxonGenus, GenusDto>, GenusTaxonDtoMapper>();
        services.AddScoped<ITaxonDtoMapper<TaxonSpecies, SpeciesDto>, SpeciesTaxonDtoMapper>();
        return services;
    }
}