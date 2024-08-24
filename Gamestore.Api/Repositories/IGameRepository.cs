using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamestore.Api.Entities;

namespace Gamestore.Api.Repositories
{
    public interface IGameRepository
    {
        void Create(Game game);

        void Delete(int id);

        Game? Get(int id);

        IEnumerable<Game> GetAll();

        void Update(Game updatedGame);
    }
}
