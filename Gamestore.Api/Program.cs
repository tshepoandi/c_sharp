using Gamestore.Api.Endpoints;
using Gamestore.Api.Repositories;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGameRepository,InMemGamesRepository>();

var connectionString = builder.Configuration.GetConnectionString("GamestoreContext");
Console.Write(connectionString);
var app = builder.Build();
app.MapGamesEndpoints();

app.Run();