using MyApp.Data;
using MyApp.Models;
using MyApp.Reposotory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPlayersRepo, PlayersRepo>();
builder.Services.AddSingleton<IGamesRepo, GamesRepo>();
builder.Services.AddSingleton<IJsonHandler<Game>, JsonHandler<Game>>();
builder.Services.AddSingleton<IJsonHandler<Player>, JsonHandler<Player>>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
