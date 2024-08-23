using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamestore.Api.Repositories
{
    public class InMemGamesRepository
    {
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
    }

    public IEnumerable<Game> GetAll()
    {
        return games;
    }
}