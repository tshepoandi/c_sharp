using GameStore.Api.Entities;

const string GetGameEndpointName = "getGame"; 

List<Game> games = new()
{
    new Game()
    {
        Id = 1,
        Name = "Street Fighter",
        Genre = "Fighting",
        Price = 19.99m,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUri = "",

    },
    new Game()
    {
        Id = 2,
        Name = "Street Fighter 2",
        Genre = "Role Playing",
        Price = 29.99m,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUri = ""
    },
    new Game()
    {
        Id = 3,
        Name = "Captain Commando",
        Genre = "Fighting",
        Price = 10.50m,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUri = ""
        
    },
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/games", ()=> games);
app.MapGet("/game/{id}", (int id) => 
    {
        Game? game = games.Find(game => game.Id == id);
        if(game is null)
        {
            return Results.NotFound();
        }
        return Results.Ok(game);
    }).WithName(GetGameEndpointName);
app.MapPost("/games", (Game game) => 
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
        return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
    }
);

app.MapPut("/games/{id}", (int id, Game updatedGame) => 
{
    Game ? existingGame = games.Find(game => game.Id == id);

    if(existingGame is null)
    {
        return Results.NotFound();
    }
    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;
    return Results.NoContent();
});

app.MapDelete("/games/{id}", (int id) => 
{
    Game? existingGame = games.Find(game => game.Id == id);
    
    if(existingGame is not null)
    {
        games.Remove(existingGame);
    }
    return Results.NoContent();
});
app.Run();
