using GameApi.Application.Protocols.Db.Game;
using GameApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameApi.Infrastructure.Helper;

namespace GameApi.Infrastructure.Db.Sqlite.Game
{
    public class GameSqliteRepository(AppDbContext context) : IGameRepository
    {
        public async Task<List<Domain.Models.Game>> Get()
        {
            return await context.Games.AsNoTracking().ToListAsync();
        }
    }
}