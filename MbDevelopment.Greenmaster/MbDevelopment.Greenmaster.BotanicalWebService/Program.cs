using MbDevelopment.Greenmaster.BotanicalWebService;
using MbDevelopment.Greenmaster.Contracts.WebApi;
using MbDevelopment.Greenmaster.Core;
using MbDevelopment.Greenmaster.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<BotanicalContext>(options => options.UseInMemoryDatabase("testDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var someSpecies = new Species[]
{
    new ()
    {
        Id = 1,
        LatinName = "Ginkgo Biloba",
        Description = "De Japanse notenboom, ginkgo, tempelboom of eendenpootboom is een boom uit de familie Ginkgoaceae. " +
                      "De soort is oorspronkelijk afkomstig uit China; hij wordt gekweekt en is niet meer in het wild bekend.",
        CommonNames =
            new [] {
                new CommonName() { Id = 1, Name = "ginkgo" },
                new CommonName() { Id = 2, Name = "japanse notenboom", UsedByLanguages = new [] { LanguageIsoCodes.Dutch }} ,
                new CommonName() { Id = 3, Name = "maidenhair tree" }
                
            }
    }
};

var someGenera = new Genus[]
{
    new() { Id = 1, LatinName = "Ginkgo", Description = "non-flowering seed plants", Species = someSpecies.Select(species => species.Id).ToArray()},
    new() { Id = 2, LatinName = "Linum" },
    new() { Id = 3, LatinName = "Strelitzia" },
};
app.MapGet(SpeciesApi.Url, () => someSpecies)
    .WithName("GetSpecies")
    .WithOpenApi();
app.MapGet(GeneraApi.Url, () => someGenera)
    .WithName("GetGenera")
    .WithOpenApi();

app.Run();

