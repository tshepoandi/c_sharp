using Gamestore.Api.Endpoints;
using Gamestore.Api.IGameRepository;
using Gamestore.Api.InMemGamesRepository;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGameRepository,InMemGamesRepository>();
var app = builder.Build();
app.MapGamesEndpoints();

app.Run();