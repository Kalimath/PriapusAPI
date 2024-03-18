using System.Reflection;
using MbDevelopment.Greenmaster.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
services.AddEndpointsApiExplorer();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
services.AddControllers();
services.AddSwaggerGen();
services.AddDbContext<BotanicalContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("localDb"));
});

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

app.UseRouting();
        
app.UseAuthorization();
app.UseEndpoints(routeBuilder => routeBuilder.MapControllers());

app.Run();