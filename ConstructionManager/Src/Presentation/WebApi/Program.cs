using Application;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Contexts;
using WebApi.Infrastructure.Extensions;
using WebApi.Infrastructure.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

bool useInMemoryDatabase = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");

// Register layers
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration, useInMemoryDatabase);

// WebApi specific services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddVersioning();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAnyCors();
builder.Services.AddCustomLocalization(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    if (!useInMemoryDatabase)
    {
        await services.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
    }

    //Seed Data
}

// Configure the HTTP request pipeline
app.UseCustomLocalization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseRouting();
app.UseCors("Any");
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerWithVersioning();
app.UseHealthChecks("/health");
app.UseSerilogRequestLogging();

app.MapControllers().RequireCors("Any");

app.Run();

public partial class Program
{
}
