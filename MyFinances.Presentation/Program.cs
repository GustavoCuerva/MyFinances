using MyFinances.Application;
using MyFinances.Infrastructure;
using MyFinances.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddOpenApi();


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

app.UseHttpsRedirection();

app.Run();