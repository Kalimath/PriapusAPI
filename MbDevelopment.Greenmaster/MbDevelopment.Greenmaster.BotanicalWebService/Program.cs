using MbDevelopment.Greenmaster.BotanicalWebService;
using MbDevelopment.Greenmaster.Core;
using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
services.AddEndpointsApiExplorer();

//services.AddControllers();
services.AddSwaggerGen();
services.AddDbContext<BotanicalContext>(options => options.UseInMemoryDatabase("testDb"));

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

var someCommonNames = new [] {
    new CommonName() { Id = 1, Name = "ginkgo", UsedByLanguages = [LanguageIsoCodes.English] },
    new CommonName() { Id = 2, Name = "japanse notenboom", UsedByLanguages = [LanguageIsoCodes.Dutch] }
};
var someSpecies = new Species[]
{
    new ()
    {
        Id = 1,
        LatinName = "Ginkgo Biloba",
        Description = "Een boom uit de familie Ginkgoaceae. " +
                      "De soort is oorspronkelijk afkomstig uit China; hij wordt gekweekt en is niet meer in het wild bekend.",
        CommonNames = someCommonNames
    }
};

var someGenera = new Genus[]
{
    new() { Id = 1, LatinName = "Ginkgo", Description = "non-flowering seed plants", Species = someSpecies.Select(species => species.Id).ToArray()},
    new() { Id = 2, LatinName = "Linum" },
    new() { Id = 3, LatinName = "Strelitzia" },
};

app.RegisterSpeciesEndpoints(someSpecies);
app.RegisterGenusEndpoints(someGenera);
app.RegisterCommonNamesEndpoints(someCommonNames);

app.Run();