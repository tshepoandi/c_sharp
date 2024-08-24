using Gamestore.Api.Endpoints;
using Gamestore.Api.Repositories;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGameRepository,InMemGamesRepository>();
var app = builder.Build();
app.MapGamesEndpoints();

app.Run();