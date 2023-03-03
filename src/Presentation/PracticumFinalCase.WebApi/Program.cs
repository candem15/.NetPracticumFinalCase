using PracticumFinalCase.Application;
using PracticumFinalCase.Infrastructure;
using PracticumFinalCase.Persistence;
using PracticumFinalCase.Persistence.Contexts;
using PracticumFinalCase.WebApi.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();

// Custom swagger implementation.
builder.Services.AddCustomizeSwagger();

// Custom jwt authentication configured.
builder.Services.AddJwtBearerAuthentication(builder.Configuration);

// Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog();

// Redis cache
builder.Services.AddRedisDependencyInjection(builder.Configuration);

builder.Services.AddControllers();
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

// Apply seeding and migration to db

app.MigrateDbContext<AppDbContext>((context, services) =>
{
    var logger = services.GetService<ILogger<AppDbContext>>();

    var dbContextSeeder = new AppDbContextSeed();

    dbContextSeeder.SeedAsync(context, logger).Wait();
});


app.UseHttpsRedirection();

// auth jtw
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
