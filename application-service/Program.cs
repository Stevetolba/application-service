using BoltOn;
using BoltOn.Cache;
using Application.Service.Application.Entities;
using Application.Service.Application.Handlers;
using CorrelationId.DependencyInjection;
using BoltOn.Data.MartenDb;
using FastEndpoints;
using FastEndpoints.Swagger;
using Marten;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Reflection;
using Application.Service.Infrastructure.Data.Mappings;
using Application.Service.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var applicationServicePostgressConnectionString = config.GetValue<string>("ApplicationServicePostgresConnectionString") ?? string.Empty;
var storeOptions = new StoreOptions();

// Add services to the container.
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddDefaultCorrelationId();

builder.Services.BoltOn(options =>
{
    options.BoltOnAssemblies(typeof(GetAllStudentsRequest).Assembly);
});
    
Log.Logger = new LoggerConfiguration()
                            .Enrich.WithMachineName()
                            .Enrich.FromLogContext()
                            .ReadFrom.Configuration(config)
                            .CreateLogger();

builder.Services.AddLogging(builder => builder.AddSerilog());

builder.Services.AddMarten(opts =>
{
    opts.Connection(applicationServicePostgressConnectionString);
    opts.CreateDatabasesForTenants(c =>
    {
        c.MaintenanceDatabase(applicationServicePostgressConnectionString)
        .ForTenant()
        .CheckAgainstPgDatabase()
        .WithOwner("bolton")
        .WithEncoding("UTF-8")
        .ConnectionLimit(-1);

    });
    opts.Schema.Include<MartenDbRegistery>();
}).OptimizeArtifactWorkflow();

builder.Services.AddTransient<BoltOn.Data.MartenDb.IRepository<Student>, BoltOn.Data.MartenDb.Repository<Student>>();
builder.Services.AddTransient<BoltOn.Data.MartenDb.IRepository<StudentFlattened>, BoltOn.Data.MartenDb.Repository<StudentFlattened>>();

builder.Services.AddTransient<BoltOn.Data.MartenDb.IQueryRepository<StudentType>, BoltOn.Data.MartenDb.QueryRepository<StudentType>>();
builder.Services.AddTransient<BoltOn.Data.MartenDb.IQueryRepository<Course>, BoltOn.Data.MartenDb.QueryRepository<Course>>();


builder.Services
  .AddAutoMapper(typeof(GetAllStudentsRequest).Assembly);

var app = builder.Build();

app.UseFastEndpoints(c =>
{
    c.Serializer.RequestDeserializer = async (req, tDto, jCtx, ct) =>
    {
        if (req.Method == "PATCH" || req.Method == "POST")
        {
            using var reader = new StreamReader(req.Body);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(await reader.ReadToEndAsync(), tDto);
        }
        else
        {
            return req.ReadFromJsonAsync(
                type: tDto,
                options: jCtx?.Options,
                cancellationToken: ct);
        }
    };
});

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(s => s.ConfigureDefaults());
}

app.UseHttpsRedirection();

app.Run();
