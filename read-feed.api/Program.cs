using Microsoft.EntityFrameworkCore;
using read_feed.api;
using read_feed.api.Data;
using read_feed.api.Services;
using read_feed.api.Infra;

var builder = WebApplication.CreateBuilder(args);

var sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));
var mapperConfig = builder.Services.AddCustomMappers();
builder.Services.AddControllers();
builder.Services.AddDbContext<ReadFeedContext>(o => o.UseSqlServer(sqlConnection));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.OperationFilter<CustomHeaderSwaggerAttribute>());
builder.Services.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    mapperConfig.AssertConfigurationIsValid();
}

using var scope = app.Services.CreateScope();
var initService = scope.ServiceProvider.GetService<InitializationService>();
if (initService is null) throw new InvalidOperationException("Can't init api");

if (app.Environment.IsProduction())
    initService.Run(); // Run all logic only when on production
else
    initService.CreateUser(); // By default only create required data

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
