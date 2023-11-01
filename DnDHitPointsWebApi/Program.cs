using DnDHitPointsServices;
using DnDHitPointsInfrastructure;
using Microsoft.EntityFrameworkCore;
using DnDHitPointsWebApi.Middleware;
using DnDHitPointsServices.Entities;
using DnDHitPointsServices.Dtos;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.OperationFilter<AddRequiredHeaderParameter>());

builder.Services.AddDbContext<HitPointsContext>(options =>
    options.UseInMemoryDatabase("HitPointsDB"));

builder.Services.AddTransient<ICharacterRepository, CharacterRepository>();
builder.Services.AddTransient<IHitPointsRepository, HitPointsRepository>();
builder.Services.AddTransient<IHitPointsService, HitPointsService>();

#region initial database data

var serviceProvider = builder.Services.BuildServiceProvider();

#region initial character data

// grab data from briv.json and add to Character Repository
string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"briv.json");
string jsonString = string.Join("", File.ReadAllLines(path));

Character character = JsonConvert.DeserializeObject<Character>(jsonString);

var characterRepository = serviceProvider.GetService<ICharacterRepository>();
if (characterRepository != null && character != null)
{
    characterRepository?.Add(character);
}
else
{
    throw new Exception("Couldn't load initial character data");
}

#endregion

#region initial hitpoints data

var context = serviceProvider.GetRequiredService<HitPointsContext>();

context.HitPoints.Add(new HitPoints()
{
    CharacterName = "Briv",
    CurrentHitPoints = 25,
    TemporaryHitPoints = 0
});
context.SaveChanges();

#endregion

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<GlobalErrorHandlerMiddleware>();
app.UseMiddleware<BasicAuthorizationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
