using MyFinances.Infrastructure;
using MyFinances.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();

string connectionStringSqlServer = builder.Configuration.GetConnectionStringOrThrow("SqlServer");
services.AddInfrastructureServices(connectionStringSqlServer);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();