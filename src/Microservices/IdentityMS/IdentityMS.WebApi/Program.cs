using IdentityMS.Business.IoC;
using IdentityMS.Business.SeedData;
using IdentityMS.Data.IoC;
using IdentityMS.WebApi.IoC;
using IdentityMS.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureSqlContext(builder.Configuration)
    .ConfigureDbContext()
    .ConfigureRepositories()
    .ConfigureAutoMapper()
    .ConfigureFluentValidation()
    .ConfigureServices()
    .ConfigureProducers()
    .ConfigureAuthentication(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.SeedDataAsync();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
