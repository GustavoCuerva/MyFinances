using MyFinances.Application;
using MyFinances.Infrastructure;
using MyFinances.Infrastructure.Configuration;
using MyFinances.Presentation.Endpoints;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, serviceProvider, configuration) => {
	configuration.ReadFrom.Configuration(context.Configuration);
});

var services = builder.Services;

services.AddOpenApi();

services.AddLogging();

string connectionStringSqlServer = builder.Configuration.GetConnectionStringOrThrow("SqlServer");

// Dependency Injection
services.AddApplicationService();
services.AddInfrastructureServices(connectionStringSqlServer);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.AddEndpointsCategory();

app.Run();