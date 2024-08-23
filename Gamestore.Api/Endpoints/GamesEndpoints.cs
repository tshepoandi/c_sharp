using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamestore.Api.Entities;

namespace Gamestore.Api.Endpoints
{
    public static class GamesEndpoints
    {
         public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
         {
            const string GetGameEndpointName = "getGame";  
            var group =  routes.MapGroup("/games")
                .WithParameterValidation();

            group.MapGet("/", ()=> games);
            group.MapGet("/{id}", (int id) => 
                {
                    Game? game = games.Find(game => game.Id == id);
                    if(game is null)
                    {
                        return Results.NotFound();
                    }
                    return Results.Ok(game);
                }).WithName(GetGameEndpointName);
            group.MapPost("/", (Game game) => 
                {
                    game.Id = games.Max(game => game.Id) + 1;
                    games.Add(game);
                    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
                }
            );


            // group.MapGet()
            group.MapPut("/{id}", (int id, Game updatedGame) => 
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

            group.MapDelete("/{id}", (int id) => 
            {
                Game? existingGame = games.Find(game => game.Id == id);
                
                if(existingGame is not null)
                {
                    games.Remove(existingGame);
                }
                return Results.NoContent();
            });
            
            return group;
         }
    }
}