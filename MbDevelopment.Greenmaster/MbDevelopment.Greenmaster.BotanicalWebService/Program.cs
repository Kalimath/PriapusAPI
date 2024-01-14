
using MbDevelopment.Greenmaster.Contracts.WebApi;
using MbDevelopment.Greenmaster.DataAccess;
using MbDevelopment.Greenmaster.DataAccess.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
services.AddEndpointsApiExplorer();

//services.AddControllers();
services.AddSwaggerGen();
services.AddDbContext<BotanicalContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("localDb"));
});

services.AddScoped<ISpeciesQueryService, SpeciesQueryService>();
services.AddScoped<IGeneraQueryService, GeneraQueryService>();
services.AddScoped<ICommonNamesQueryService, CommonNamesQueryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
//TODO: add health-check for potential missing dependency injections

app.UseHttpsRedirection();

    var speciesItems = app.MapGroup(SpeciesApi.Url);
    speciesItems.MapGet("/", GetAllSpecies);

    var commonNamesItems = app.MapGroup(CommonNamesApi.Url);
    commonNamesItems.MapGet("/", GetAllCommonNames);

    var generaItems = app.MapGroup(GeneraApi.Url);
    generaItems.MapGet("/", GetAllGenera);
    generaItems.MapGet("/{id}", GetGenusById);

    static async Task<IResult> GetAllSpecies(ISpeciesQueryService service) 
        => TypedResults.Ok(await service.GetAll());

    static async Task<IResult> GetAllCommonNames(ICommonNamesQueryService service) 
        => TypedResults.Ok(await service.GetAll());

    static async Task<IResult> GetAllGenera(IGeneraQueryService service) 
        => TypedResults.Ok(await service.GetAll());

    static async Task<IResult> GetGenusById(int id, IGeneraQueryService service) 
    {
        var result = await service.GetById(id);
        
        return result is not null ? TypedResults.Ok(result) : TypedResults.NotFound();
    }

    app.Run();