using Core.Repositories;
using ITIWEB.APIs.Errors;
using ITIWEB.APIs.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped(typeof(IGenericRepository<>) , typeof(GenericRepository<>));
//old way
//builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState.Where(M => M.Value.Errors.Count > 0)
                        .SelectMany(M => M.Value.Errors)
                        .Select(E => E.ErrorMessage)
                        .ToArray();
        var errorResponse = new ApiValidationErrorResponse()
        {
            Errors = errors
        };
        return new BadRequestObjectResult(errorResponse);
        
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// StaticFiles
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
//var context = services.GetRequiredService<StoreContext>();

try
{
    var context = services.GetRequiredService<StoreContext>();
    await StoreContextSeed.SeedAsync(context, loggerFactory);
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var Logger = loggerFactory.CreateLogger<Program>();
    Logger.LogError(ex.Message);
}
app.Run();
