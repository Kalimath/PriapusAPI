using MbDevelopment.Greenmaster.Contracts.WebApi;

namespace MbDevelopment.Greenmaster.BotanicalWebService;

public static class MinimalApiEndpoints
{
    public static void RegisterSpeciesEndpoints(this WebApplication app, Species[] species) 
    {
        //TODO: convert to post and pass languageCode for common names
        //TODO: only pass array of matching names for common names
        app.MapGet(SpeciesApi.Url, () => species)
            .WithName("GetAllSpecies")
            .WithOpenApi();
    }

    public static void RegisterCommonNamesEndpoints(this WebApplication app, CommonName[] commonNames)
    {
        app.MapGet(CommonNamesApi.Url, () => commonNames)
            .WithName("GetAllCommonNames")
            .WithOpenApi();
    }

    public static void RegisterGenusEndpoints(this WebApplication app, Genus[] genera)
    {
        app.MapGet(GeneraApi.Url, () => genera)
            .WithName("GetAllGenera")
            .WithOpenApi();
    }
}