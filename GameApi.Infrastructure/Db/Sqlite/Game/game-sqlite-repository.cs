using GameApi.Application.Protocols.Db.Game;
using GameApi.Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;

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