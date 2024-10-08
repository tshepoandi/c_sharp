using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamestore.Api.Entities;
using Gamestore.Api.Repositories;
using Gamestore.Api.Dtos;

namespace Gamestore.Api.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndpointName = "getGame"; 
        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {
            var group =  routes.MapGroup("/games")
                .WithParameterValidation();
            
            group.MapGet("/", (IGameRepository repository)=> 
                repository.GetAll().Select(game => game.AsDto()));
            group.MapGet("/{id}", (IGameRepository repository,int id) => 
                {
                    Game? game = repository.Get(id);
                    return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
                    
                }).WithName(GetGameEndpointName);
            group.MapPost("/", (CreateGameDto gameDto,IGameRepository repository) => 
                {
                    Game game = new()
                    {
                        Name = gameDto.Name,
                        Genre = gameDto.Genre,
                        Price = gameDto.Price,
                        ReleaseDate = gameDto.ReleaseDate,
                        ImageUri = gameDto.ImageUri,
                    };
                    repository.Create(game);
                    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
                }
            );

            group.MapPut("/{id}", (IGameRepository repository,int id, UpdateGameDto updatedGame) => 
            {
                Game ? existingGame = repository.Get(id);

                if(existingGame is null)
                {
                    return Results.NotFound();
                }
                existingGame.Name = updatedGame.Name;
                existingGame.Genre = updatedGame.Genre;
                existingGame.Price = updatedGame.Price;
                existingGame.ReleaseDate = updatedGame.ReleaseDate;
                existingGame.ImageUri = updatedGame.ImageUri;

                repository.Update(existingGame);
                return Results.NoContent();
            });

            group.MapDelete("/{id}", (IGameRepository repository,int id) => 
            {
                Game? game = repository.Get(id);
                
                if(game is not null)
                {
                    repository.Delete(id);
                }
                return Results.NoContent();
            });
            
            return group;
         }
    }
}