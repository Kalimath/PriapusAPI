using MbDevelopment.Greenmaster.BotanicalWebService;

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
        Name = "Ginkgo Biloba",
        Description = "De Japanse notenboom, ginkgo, tempelboom of eendenpootboom is een boom uit de familie Ginkgoaceae. " +
                      "De soort is oorspronkelijk afkomstig uit China; hij wordt gekweekt en is niet meer in het wild bekend.",
        CommonNames = ["Japanse notenboom", "ginkgo", "tempelboom", "eendenpootboom"]
    }
};

app.MapGet("/species", () => someSpecies)
    .WithName("GetSpecies")
    .WithOpenApi();

app.Run();

