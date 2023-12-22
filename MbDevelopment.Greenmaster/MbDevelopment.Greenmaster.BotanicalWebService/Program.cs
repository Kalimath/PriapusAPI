using MbDevelopment.Greenmaster.BotanicalWebService;
using MbDevelopment.Greenmaster.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
            [
                new CommonName() { Id = 1, Name = "ginkgo" },
                new CommonName() { Id = 2, Name = "japanse notenboom", UsedByLanguages = [LanguageIsoCodes.Dutch] },
                new CommonName() { Id = 3, Name = "maidenhair tree" }
            ]
    }
};

var someGenera = new Genus[]
{
    new() { Id = 1, LatinName = "Ginkgo", Description = "non-flowering seed plants", Species = someSpecies.Select(species => species.Id).ToArray()},
    new() { Id = 2, LatinName = "Linum" },
    new() { Id = 3, LatinName = "Strelitzia" },
};
app.MapGet("/species", () => someSpecies)
    .WithName("GetSpecies")
    .WithOpenApi();
app.MapGet("/genus", () => someGenera)
    .WithName("GetGenera")
    .WithOpenApi();

app.Run();

