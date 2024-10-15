using GameApi.Application.Protocols.Db.Game;
using GameApi.Domain.Models;

namespace GameApi.Application.UseCases
{
    public class InsertGame (IGameRepository insertGameRepository)
    {
        public async Task Execute(IEnumerable<Game> games)
        {
            foreach (var game in games)
            {
                await insertGameRepository.Insert(game);
            }
        }
    }
}