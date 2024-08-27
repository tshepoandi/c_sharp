using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamestore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Api.Data
{
    public class GamestoreContext : DbContext
    {
        public GamestoreContext(DbContextOptions<GamestoreContext> options) :
            base(options)
        {
        }

        public DbSet<Game> Games => Set<Game>();
    }
}
