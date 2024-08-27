using Gamestore.Api.Endpoints;
using Gamestore.Api.Repositories;
using Gamestore.Api.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGameRepository,InMemGamesRepository>();

var connectionString = builder.Configuration.GetConnectionString("GamestoreContext");
Console.Write(connectionString);
builder.Services.AddSqlServer<GamestoreContext>(connectionString);
// var app = builder.Build();
// app.MapGamesEndpoints();

// app.Run();